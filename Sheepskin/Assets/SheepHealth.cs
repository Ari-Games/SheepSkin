using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHealth : MonoBehaviour
{
    [SerializeField]int health = 1;
    void Start()
    {
        
    }

    public void DecHealth(GameObject PuddleOfBlood,bool PuddleDisappeare,float PuddleDisappearanceTime,ref int res)
    {
        health -= 1;
        if (health == 0)
        {
            Destroy(gameObject);
            Player.Instance.EatSheep();
            GameObject.FindGameObjectWithTag("Core").GetComponent<UpdateWorld>().PlayRandomClip();
            var puddle = Instantiate(PuddleOfBlood,transform.position, Quaternion.identity);// made puddle 
            res += 1;

            if (PuddleDisappeare)
            {
                Destroy(puddle, PuddleDisappearanceTime);
            }
        }


    }
    void Update()
    {
        
    }
}
