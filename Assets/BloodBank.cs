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
    private float capacity = 100f;
    [SerializeField] private TMPro.TextMeshProUGUI progressText;
    public GameObject prompt;

    private void Awake()
    {
        prompt.SetActive(false);
    }

    void FixedUpdate()
    {
        if (donating && !full)
        {
            currentBlood += donateRate;
            GameManager.GM.ChangeHeath(-(int)donateRate);

            if (currentBlood >= capacity)
            {
                currentBlood = capacity;
                full = true;
            }

            blood.material.SetFloat("_Progress", (currentBlood / capacity)*2);

            progressText.text = $"Blood Gate\n{(currentBlood / capacity) * 100}%";
        }
    }
}
