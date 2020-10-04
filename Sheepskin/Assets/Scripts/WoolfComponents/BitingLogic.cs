#define DEBUGING_BITINGLOGIC
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BitingLogic : MonoBehaviour
{
    [SerializeField] GameObject HeroSprite;   
    [SerializeField] LayerMask IgnoreMe;

    [Header("Sprite Settings")]
    [SerializeField] ParticleSystem BloodParticle;
    [SerializeField] GameObject PuddleOfBlood;
    [Header("Puddle Settings")]
    [SerializeField] bool PuddleDisappeare = false;
    [SerializeField] float PuddleDisappearanceTime = 1f;
    int satiety = 0;
    [Header("Animation Settings")]
    [SerializeField] AnimationClip[] walkingAnimationClip;
    [SerializeField] AnimationClip[] idleAnimationClip;
    AnimatorOverrideController animatorOverrideController;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
       
        
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
        //animatorOverrideController["idle"] = idleAnimationClip[3];
    }
    bool _flag = false;
    int count = 0;
    int res = 0;
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(HeroSprite.transform.position,HeroSprite.transform.up,3,~IgnoreMe);
        
        if (hit.collider != null && hit.collider.tag == "Sheep" && Input.GetKeyDown(KeyCode.Space) && !_flag)         {
            var blood = Instantiate(BloodParticle,hit.collider.transform);// made splash            
            blood.Play();
            Destroy(blood, 2);
            
            if (res == 2 && count<walkingAnimationClip.Length)
            {
                count += 1;
                animatorOverrideController["idle"] = idleAnimationClip[count];
                animatorOverrideController["walking"] = walkingAnimationClip[count];
                animatorOverrideController["idle2"] = walkingAnimationClip[count];
                res = 0;
            }
            hit.collider.gameObject.GetComponent<SheepHealth>().DecHealth(PuddleOfBlood,PuddleDisappeare, PuddleDisappearanceTime,ref res);
            _flag = true;
            Invoke("SetFlagFalse", 0.1f);
            
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
