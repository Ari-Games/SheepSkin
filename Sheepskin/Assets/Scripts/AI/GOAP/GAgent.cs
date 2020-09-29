﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Goap
{
    public class SubGoal {

        // Dictionary to store our goals
        public Dictionary<string, int> sGoals;
        // Bool to store if goal should be removed after it has been achieved
        public bool remove;

        // Constructor
        public SubGoal(string s, int i, bool r) {

            sGoals = new Dictionary<string, int>();
            sGoals.Add(s, i);
            remove = r;
        }
    }

    public class GAgent : MonoBehaviour {

        // Store our list of actions
        public List<GAction> actions = new List<GAction>();
        // Dictionary of subgoals
        public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();
        
        public GInventory inventory  = new GInventory();
        public WorldStates beliefs = new WorldStates();

        // Access the planner
        GPlanner planner;
        // Action Queue
        Queue<GAction> actionQueue;
        // Our current action
        public GAction currentAction;
        // Our subgoal
        SubGoal currentGoal;

        Vector3 destination = Vector2.zero;

        [SerializeField]
        Rigidbody2D rBody = new Rigidbody2D();

        // [SerializeField]
        public float distanceForComplete = 2f;

        public bool isAgentStop = true;



        // Start is called before the first frame update
        public void Start() {

            GAction[] acts = this.GetComponents<GAction>();
            foreach (GAction a in acts) {

                actions.Add(a);
            }
        }

        bool invoked = false;
        //an invoked method to allow an agent to be performing a task
        //for a set location
        public void CompleteAction() {

            currentAction.running = false;
            currentAction.PostPerform();
            invoked = false;
        }

        void LateUpdate() {

            
            //if there's a current action and it is still running
            if (currentAction != null && currentAction.running) {
                
                // Find the distance to the target
                float distanceToTarget = Vector2.Distance(destination, this.transform.position);
                
                // Check the agent has a goal and has reached that goal
                if (distanceToTarget < distanceForComplete) { // currentAction.agent.remainingDistance < 1.0f) 
                    ///
                    if(isAgentStop)
                        currentAction.agent.isStopped = true;
                    ///
                    if (!invoked) {
                        //if the action movement is complete wait
                        //a certain duration for it to be completed
                        Invoke("CompleteAction", currentAction.duration);
                        invoked = true;
                    }
                }
                return;
            }

            // Check we have a planner and an actionQueue
            if (planner == null || actionQueue == null) {

                // If planner is null then create a new one
                planner = new GPlanner();

                // Sort the goals in descending order and store them in sortedGoals
                var sortedGoals = from entry in goals orderby entry.Value descending select entry;

                //look through each goal to find one that has an achievable plan
                foreach (KeyValuePair<SubGoal, int> sg in sortedGoals) {

                    actionQueue = planner.plan(actions, sg.Key.sGoals, beliefs);
                    // If actionQueue is not = null then we must have a plan
                    if (actionQueue != null) {

                        // Set the current goal
                        currentGoal = sg.Key;
                        break;
                    }
                }
            }

            // Have we an actionQueue
            if (actionQueue != null && actionQueue.Count == 0) {

                // Check if currentGoal is removable
                if (currentGoal.remove) {

                    // Remove it
                    goals.Remove(currentGoal);
                }
                // Set planner = null so it will trigger a new one
                planner = null;
            }

            // Do we still have actions
            if (actionQueue != null && actionQueue.Count > 0) {

                // Remove the top action of the queue and put it in currentAction
                currentAction = actionQueue.Dequeue();

                if (currentAction.PrePerform()) {

                    // Get our current object
                    if (currentAction.target == null && currentAction.targetTag != "") {

                        currentAction.target = GameObject.FindWithTag(currentAction.targetTag);
                    }

                    if (currentAction.target != null)
                    {

                        // Activate the current action
                        currentAction.running = true;
                        //print(currentAction.target);
                        // InvokeRepeating("GoToTarget",0f,0.5f);
                        currentAction.agent.isStopped = false;
                        // // Pass Unities AI the destination for the agent
                        destination = (Vector2)currentAction.target.transform.position;
                        Transform isDestExist = currentAction.target.transform.Find("Destination");
                        if(isDestExist)
                            destination = (Vector2)isDestExist.position;
                        currentAction.agent.SetDestination(new Vector2(destination.x,destination.y));
                    }
                } else {

                    // Force a new plan
                    actionQueue = null;
                }
            }
        }

        private void GoToTarget()
        {
            var dir = transform.position - currentAction.target.transform.transform.position;
            rBody.GetComponent<Rigidbody2D>().MovePosition(transform.position - dir *5f*Time.deltaTime);
        }
    }
}