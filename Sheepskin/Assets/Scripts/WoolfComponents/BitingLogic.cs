#define DEBUGING_BITINGLOGIC
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitingLogic : MonoBehaviour
{
    [SerializeField] GameObject HeroSprite;   
    [SerializeField] LayerMask IgnoreMe;
    [SerializeField] ParticleSystem BloodParticle;
    [SerializeField] GameObject PuddleOfBlood;
    void Start()
    {
        
    }

    bool _flag = false;
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(HeroSprite.transform.position,HeroSprite.transform.up,3,~IgnoreMe);
        
        if (hit.collider != null && hit.collider.tag == "Sheep" && Input.GetKeyDown(KeyCode.Space) && !_flag) 
        {
            var blood = Instantiate(BloodParticle,hit.collider.transform);
            Instantiate(PuddleOfBlood, hit.collider.gameObject.transform.position,Quaternion.identity);
            blood.Play();
            Destroy(blood, 2);
            Destroy(hit.collider.gameObject,0.5f);
            Debug.Log(hit.collider.gameObject.name);
            _flag = true;
            Invoke("SetFlagFalse", 3f);
        }
#if DEBUGING_BITINGLOGIC
            Debug.DrawRay(transform.position, transform.position + HeroSprite.transform.up,Color.red);
#endif

    }
    void SetFlagFalse()
    {
        _flag = false;

    }

}
