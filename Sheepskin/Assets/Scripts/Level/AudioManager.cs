using Goap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip dangerous;
        [SerializeField] private AudioClip relax;

        private bool flag = false;

        private void Start()
        {
            GetComponent<AudioSource>().clip = relax;
            GetComponent<AudioSource>().Play();
        }

        private void Update()
        {
            if (GWorld.Instance.GetWorld().HasState("TimeToBeBeast") && !flag)
            {
                GetComponent<AudioSource>().clip = dangerous;
                GetComponent<AudioSource>().Play();
                flag = true;
            }
            if (!GWorld.Instance.GetWorld().HasState("TimeToBeBeast") && flag)
            {
                GetComponent<AudioSource>().clip = relax;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
