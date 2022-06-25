using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _GM;
    public static GameManager GM { get { return _GM; } }
    public int maxHealth = 1000;
    public int Health = 100;

    public int currentLevel = 4;

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
        Invoke("fallInToNextLevel", 5); //Please delete me
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
    internal void fallInToNextLevel()
    {
      GameObject[] enemies =  GameObject.FindGameObjectsWithTag("EnemyHitbox");
        for (int i = 0; i < enemies.Length; i ++)
        {
          Destroy(  enemies[i]);
        }
        GameObject.FindWithTag("fallSprite").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindWithTag("fallDownCamera").GetComponent<Camera>().enabled = true;
        GameObject.FindWithTag("fallSprite").GetComponent<Animator>().enabled = true;
        GameObject.FindWithTag("fallSprite").transform.position = new Vector3(0, 63, 0); 
        GameObject.FindWithTag("fallSprite").transform.position += returnLevelPlane();
        GameObject.FindWithTag("Player").GetComponentInChildren<SpriteRenderer>().enabled = false;


    }

    public Vector3 returnLevelPlane() //Every Next Level is -60 on the y axis from the last one
    { //Please Move this function somewhere else
        return new Vector3 (0, (4 - currentLevel ) * -60, 0); //Magic number 4 is just the starting floor number which in turn dictates the total amount of floor
    }

    internal void StartNewLevel()
    {
        DisplaylevelText();
        currentLevel--;
        GameObject.FindWithTag("fallDownCamera").GetComponent<Camera>().enabled = false;
        GameObject.FindWithTag("fallSprite").GetComponent<Animator>().enabled = false;
     
        GameObject.FindWithTag("Player").transform.position = new Vector3(0, 63, 0) + new Vector3(0, returnLevelPlane().y, 0); ;
        
       
        GameObject.FindWithTag("Player").GetComponentInChildren<SpriteRenderer>().enabled = true;
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