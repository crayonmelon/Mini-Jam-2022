using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBank : MonoBehaviour
{
    public bool donating = false;
    private bool full = false;
    [SerializeField] private float donateRate = 5;
    [SerializeField] private MeshRenderer blood;
    private float currentBlood = 0f;
    [SerializeField] private float capacity = 100f;
    [SerializeField] private TMPro.TextMeshProUGUI progressText;
    public GameObject prompt;
    [SerializeField] AudioClip bloodPourSfx;


    private void Awake()
    {
        prompt.SetActive(false);
    }

    void FixedUpdate()
    {
        if (donating && !full)
        {
            if (this.GetComponent<AudioSource>().isPlaying != true)
            {
                this.GetComponent<AudioSource>().PlayOneShot(bloodPourSfx);
            }
            currentBlood += donateRate;
            GameManager.GM.ChangeHealth(-(int)donateRate);

            if (currentBlood >= capacity)
            {
                currentBlood = capacity;
                full = true;
            }

            blood.material.SetFloat("_Progress", (currentBlood / capacity)*2);

            progressText.text = $"Blood Gate\n{(currentBlood / capacity) * 100}%";
        }

        if (full)
        {
            Debug.Log("OHNO");
           
            GameManager.GM.fallInToNextLevel();
            Destroy(gameObject);
        }
    }
}
