using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //public static HealthBar Instance;
    private int maxHealth => GameManager.GM.maxHealth;
    private int currentHealth => GameManager.GM.Health;
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private Transform scalePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = $"{currentHealth}/{maxHealth}";
        scalePoint.localScale = scalePoint.localScale.With(x: (float)currentHealth / maxHealth);
    }
}
