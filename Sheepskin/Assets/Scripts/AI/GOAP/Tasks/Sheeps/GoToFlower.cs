using System.Collections;
using System.Collections.Generic;
using Goap;
using UnityEngine;

public class GoToFlower : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("flowers").RemoveResource();
        if (target == null)
            return false;

        InvokeRepeating("RotateTo",0,0.01f);
        
        if (GetComponent<Flocking.Flock>())
        {
            GetComponent<Flocking.Flock>().enabled = false;
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        return true;
    }

    private void RotateTo()
    {
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, angle - 90), Time.deltaTime * 5);
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("FreeFlower", -1);
        target.SetActive(false);
        beliefs.RemoveState("isHungry");
        GetComponent<Flocking.Flock>().enabled = true;
        CancelInvoke("RotateTo");
        return true;
    }
}
