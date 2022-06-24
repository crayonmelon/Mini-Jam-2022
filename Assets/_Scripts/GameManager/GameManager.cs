using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _GM;
    public static GameManager GM { get { return _GM; } }
    public int Health = 100;

    public int Level = 0;

    void Awake()
    {
        if (_GM != null && _GM != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _GM = this;
        }
    }

    internal void ChangeHeath(int health)
    {
        Health += health;

        if (Health <= 0 )
        {
            Died();
        }
    }

    private void Died()
    {
        Debug.Log("DIED DIED DIED DIED DIED");
    }


}
