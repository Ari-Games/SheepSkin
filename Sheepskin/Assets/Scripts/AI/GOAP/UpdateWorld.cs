using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using Goap;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour
{
    public Text states;
    private GameObject[] flowers = null;

    [SerializeField] 
    GameObject playerObj = null;

    [SerializeField] private List<AudioClip> clips;

    public void PlayRandomClip()
    {
        int index = Random.Range(0, clips.Count);
        //GetComponent<AudioSource>().clip = clips[index];
        GetComponent<AudioSource>().PlayOneShot(clips[index]);
    }

    private void Awake()
    {
        flowers = GameObject.FindGameObjectsWithTag("Flower");
        foreach(var flower in flowers)
        {
            flower.SetActive(false);
        }
    }

    private void Start() 
    {
        InvokeRepeating("InstantFlower",Random.Range(10,15),Random.Range(20, 25));
    }

    void Update()
    {
        if(!Player.Instance.IsLife)
        {
            playerObj.GetComponent<MoveController>().enabled = false;
            playerObj.GetComponent<AttackController>().enabled = false;
        }
    }

    void AddSheepAwayState()
    {
        if(Random.Range(1,8) == 1 && !GWorld.Instance.GetWorld().HasState("Away"))
        {
            print("AWAY!");
            var point = GameObject.FindGameObjectWithTag("Away");
            GWorld.Instance.GetQueue("awayPoints").AddResource(point);
            GWorld.Instance.GetWorld().ModifyState("Away",1);
        }
    }

    private void InstantFlower()
    {
        if(!GWorld.Instance.GetWorld().HasState("FreeFlower"))
        {
            var indexOfFlower = Random.Range(0, flowers.Length - 1);
            var instant = flowers[indexOfFlower];
            instant.SetActive(true);
            GWorld.Instance.GetWorld().ModifyState("FreeFlower",1);
            GWorld.Instance.GetQueue("flowers").AddResource(instant);
        }
    }
}
