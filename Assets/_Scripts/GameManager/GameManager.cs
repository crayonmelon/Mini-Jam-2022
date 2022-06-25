using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _GM;
    public static GameManager GM { get { return _GM; } }
    public int Health = 100;

    public int currentLevel = 0;

    public Level[] levels;

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

        if (Health <= 0)
        {
            Died();
        }
    }

    private void Died()
    {
        Debug.Log("DIED DIED DIED DIED DIED");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    internal void AddEnemy(GameObject enemy)
    {
        foreach (var level in levels)
        {
            if (level.ID == currentLevel)
            {
                level.Enemies.Add(enemy);
            }
        }
    }
}

[System.Serializable]
public class Level {
    [SerializeField]
    internal int ID;
    [SerializeField]
    internal List<GameObject> Enemies;
}