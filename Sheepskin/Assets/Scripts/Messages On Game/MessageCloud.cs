using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageCloud : MonoBehaviour
{
    [SerializeField]
    Transform childText = null;
    bool isActive = false;
    [SerializeField]
    TextMesh quotes;

    private void Start() {
        childText = gameObject.transform.GetChild(0);
        childText.gameObject.SetActive(false);
    }
    public void DoMessage(List<string> messages)
    {
        if(!isActive)
            StartCoroutine("Message",messages);
    }

    public bool MessageActivity
    {
        get{ return isActive;}
        set {
                isActive = value;
            }
    }

    IEnumerator Message(List<string> messages)
    {
        isActive = true;
        childText.gameObject.SetActive(true);
        quotes.text = messages[Random.Range(0,messages.Count-1)];
        yield return new WaitForSeconds(3f);
        childText.gameObject.SetActive(false);
    } 
    
}
