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

    void FixedUpdate()
    {
        if (donating && !full)
        {
            currentBlood += donateRate;

            if (currentBlood >= capacity)
            {
                currentBlood = capacity;
                full = true;
            }

            blood.material.SetFloat("_Progress", currentBlood / capacity);

            progressText.text = $"Blood Gate\n{(currentBlood / capacity) * 100}%";
        }
    }
}
