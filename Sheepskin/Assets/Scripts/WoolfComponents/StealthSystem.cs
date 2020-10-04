using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StealthSystem : MonoBehaviour
{
    public bool Secrecy { get; private set; }
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            SceneManager.LoadScene(3);
            return;
        }
        if (collision.tag != "Tree")
        {
            return;
        }
        
        Color SpriteRenderer = collision.GetComponent<SpriteRenderer>().color;        
        SpriteRenderer.a = 0.5f;
        collision.GetComponent<SpriteRenderer>().color = SpriteRenderer;
        Secrecy = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Tree")
        {
            return;
        }
        Color SpriteRenderer = collision.GetComponent<SpriteRenderer>().color;
        SpriteRenderer.a = 1f;
        collision.GetComponent<SpriteRenderer>().color = SpriteRenderer;
        Secrecy = false;
    }


    void Update()
    {
        
    }
}
