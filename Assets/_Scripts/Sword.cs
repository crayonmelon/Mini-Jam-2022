using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    private Transform lookPivot;
    private Animator anim;
    private GameObject sword;
    [SerializeField] private Transform swordScalePoint;
    [SerializeField] AudioClip swordSlashSound;
    private void Awake()
    {
        lookPivot = transform.parent.parent;
        transform.parent.parent = null;

        anim = GetComponent<Animator>();
        anim.enabled = false;

        sword = transform.GetChild(0).gameObject;
        sword.SetActive(false);
    }

    public void disableAnimator()
    {
        anim.enabled = false;
        sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        swordScalePoint.localScale = swordScalePoint.localScale.With(y: GameManager.GM.Health / 100f);
        swordScalePoint.GetChild(0).localScale = swordScalePoint.GetChild(0).localScale.With(y: GameManager.GM.Health / 100f); //Sorry Evan I  seperated the box collider from the sprite
        transform.parent.position = lookPivot.position;
    }

    

    public void HandleSwingInput(InputAction.CallbackContext context)
    {
        transform.parent.eulerAngles = lookPivot.eulerAngles;
        sword.SetActive(true);
        this.GetComponent<AudioSource>().PlayOneShot(swordSlashSound);
        transform.eulerAngles = lookPivot.eulerAngles;
        anim.enabled = true;

    }
    
    
}
