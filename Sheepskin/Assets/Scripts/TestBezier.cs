using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    enum States
    {
        Task1,
        Task2,
        Win,
    }

    public class TestBezier : MonoBehaviour
    {

        public Transform P0;
        public Transform P1;
        public Transform P2;
        public Transform P3;

        [Range(0, 1)]
        public float t;

        public IEnumerator Move()
        {
            while (t < 1)
            {
                transform.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
                t += 0.025f;
                yield return new WaitForSeconds(0.05f);
            }
            transform.localScale = new Vector3(-1, 1, 1);
            while (t > 0)
            {
                transform.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
                t -= 0.025f;
                yield return new WaitForSeconds(0.05f);
            }
            transform.localScale = new Vector3(1, 1, 1);
            StartCoroutine(Move());
            yield return null;
        }

        void Start()
        {
            StartCoroutine(Move());
        }


        private void OnDrawGizmos()
        {

            int sigmentsNumber = 20;
            Vector3 preveousePoint = P0.position;

            for (int i = 0; i < sigmentsNumber + 1; i++)
            {
                float paremeter = (float)i / sigmentsNumber;
                Vector3 point = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, paremeter);
                Gizmos.DrawLine(preveousePoint, point);
                preveousePoint = point;
            }

        }
    }
}