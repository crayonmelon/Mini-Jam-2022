using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallSpriteScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
