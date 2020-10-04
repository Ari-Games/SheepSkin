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
            Goap.GWorld.sheepLeftCount -= 1;
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
