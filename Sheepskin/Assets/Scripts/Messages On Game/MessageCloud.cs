using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCloud : MonoBehaviour
{
    [SerializeField]
    Transform childText = null;
    bool isActive = false;

    private void Start() {
        childText = gameObject.transform.GetChild(0);
        childText.gameObject.SetActive(false);
    }
    public void DoMessage()
    {
        if(!isActive)
            StartCoroutine("Message");
    }

    public bool MessageActivity
    {
        get{ return isActive;}
        set {
                isActive = value;
            }
    }

    IEnumerator Message()
    {
        isActive = true;
        childText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        childText.gameObject.SetActive(false);
    } 
    
}
