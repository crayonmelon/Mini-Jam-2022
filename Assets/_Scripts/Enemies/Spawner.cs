using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int level = 4;
    [SerializeField] GameObject spawnee;
    [SerializeField] float min = 1f;
    [SerializeField] float max = 2f;
    [SerializeField] int maxSpawn = 5;
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        yield return null;

        while (true)
        {
            if (GameManager.GM.currentLevel == level)
            {
                yield return new WaitForSeconds(Random.Range(min, max));
                Instantiate(spawnee, transform.position, transform.rotation);
            }
        }
    }
}
