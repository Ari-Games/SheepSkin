using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;
using UnityEngine.AI;

public class Sheep : GAgent
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject wolf = null;
    
    public float distanceFromWolf = 1f;
    new void Start()
    {
        wolf = GameObject.FindWithTag("Player");
        base.Start();
        SubGoal s1 = new SubGoal("goToFlower", 1, false);
        goals.Add(s1, 1);

        InvokeRepeating("TimeToHungry", 0, Random.Range(60f, 70f));
    }
    private void Update()
    {
        if (DistanceFromWolf() && !GWorld.Instance.GetWorld().HasState("BewareDogs"))
        {
            GWorld.Instance.GetWorld().ModifyState("BewareDogs",1);
            GWorld.Instance.SetLastWolfPosition(wolf.transform.position);
        }
        
    }

    public void ChangeSpeed(float speedNav)
    {
        GetComponent<NavMeshAgent>().speed = speedNav;
    }

    private bool DistanceFromWolf()
    {    
        return Vector2.Distance(transform.position, wolf.transform.position) < distanceFromWolf;
    }

    private void TimeToHungry()
    {
        if(!beliefs.HasState("isHungry"))
        {
            beliefs.ModifyState("isHungry",1);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(transform.position, distanceFromWolf);
    }
}
