using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _GM;
    public static GameManager GM { get { return _GM; } }
    public int maxHealth = 100;
    public int Health = 100;

    public int currentLevel = 0;

    public Level[] levels;

    [SerializeField] GameObject TextCanvas;

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
        StartNewLevel();
    }

    internal void ChangeHeath(int health)
    {
        Health += health;

        if (Health <= 0)
        {
            Died();
        } 
        else if (Health > maxHealth)
        {
            health = maxHealth;
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

    internal void RemoveEnemy(GameObject enemy)
    {
        foreach (var level in levels)
        {
            if (level.ID == currentLevel)
            {
                level.Enemies.Remove(enemy);
            }
        }
    }

    internal void StartNewLevel()
    {
        DisplaylevelText();
    }

    internal void DisplaylevelText()
    {
        StartCoroutine(TextDisplayEvent());
    }

    IEnumerator TextDisplayEvent()
    {
        TextCanvas.SetActive(true);

        string titleText= "";

        foreach (var level in levels)
        {
            if (level.ID == currentLevel)
            {
                titleText = level.levelText;
            }
        }

        TextCanvas.GetComponent<UpdateDisplayText>().SetText(currentLevel, titleText);
        yield return new WaitForSeconds(2f);
        TextCanvas.SetActive(false);


    }
}

[System.Serializable]
public class Level {
    [SerializeField]
    internal int ID;
    [SerializeField]
    internal string levelText;
    [SerializeField]
    internal List<GameObject> Enemies;

}