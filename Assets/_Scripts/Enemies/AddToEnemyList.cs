using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToEnemyList : MonoBehaviour
{
    void OnEnable()
    {
        GameManager.GM.AddEnemy(gameObject);
    }
}