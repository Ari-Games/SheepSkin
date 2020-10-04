using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.UI
{
    public class SmokeManagerMainMenu : MonoBehaviour
    {
        [SerializeField] private List<Transform> leftSmokes;
        [SerializeField] private List<Transform> rightSmokes;

        [SerializeField] private Transform point1;
        [SerializeField] private Transform point2;

        [SerializeField] private float speed = 0.5f;

        // Use this for initialization
        private void Start()
        {
            foreach (var smoke in leftSmokes)
                smoke.position = point1.position;

            foreach (var smoke in rightSmokes)
                smoke.position = point2.position;

        }

        private void MovedSmokes()
        {
            foreach(var smoke in leftSmokes)
                smoke.position = Vector3.MoveTowards(smoke.position, point2.position, speed);
            foreach (var smoke in rightSmokes)
                smoke.position = Vector3.MoveTowards(smoke.position, point1.position, speed);
        }

        private void CheckSmokes()
        {
            foreach (var smoke in leftSmokes)
                if (Vector3.Distance(smoke.position, point2.position) < 1e-3)
                    smoke.position = point1.position;
            foreach (var smoke in rightSmokes)
                if (Vector3.Distance(smoke.position, point1.position) < 1e-3)
                    smoke.position = point2.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            CheckSmokes();
            MovedSmokes();
        }
    }
}