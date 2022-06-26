using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeVeal : MonoBehaviour
{
    private int bankCount;

    private float Health = 1;

    [SerializeField] private Transform HealthBar;

    private void Awake()
    {
        bankCount = GetComponentsInChildren<BloodBank>().Length;
    }

    public void TakeDamage()
    {
        Health -= 1f / bankCount;
        HealthBar.localScale = HealthBar.localScale.With(x: Health);

        if (Health == 0)
        {
            print("ohno am dead");
        }
    }
}
