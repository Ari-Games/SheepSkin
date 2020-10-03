using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackController : MonoBehaviour
{
    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    public void Attack()
    {
        SetAnimation("attack");
    }

    public void Shove()
    {
        
        SetAnimation("shove");
    }
    void SetAnimation(string anim_name)
    {
        _animator.Play(anim_name);
        
    }
    public void EndOfAnim()
    {
        _animator.Play("idle");
    }
}
