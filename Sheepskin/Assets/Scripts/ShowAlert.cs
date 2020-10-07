using Goap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAlert : MonoBehaviour
{
    public GameObject panel;
    private bool flag = false;

    private void Start()
    {
        flag = false;
    }
    void Update()
    {
        if (GWorld.Instance.GetWorld().HasState("TimeToBeBeast") && !flag)
        {
            flag = true;
            StartCoroutine(Show());
        }
    }

    private IEnumerator Show()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(3f);
        panel.SetActive(false);
    }
}
