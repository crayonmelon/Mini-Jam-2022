using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallSpriteScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void killAnim()
    {
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        GameManager.GM.StartNewLevel();
    }
}
