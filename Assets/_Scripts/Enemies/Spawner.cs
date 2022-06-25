using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int level = 4;
    [SerializeField] List<SpawnChance> spawnees;

    [SerializeField] float min = 1f;
    [SerializeField] float max = 2f;
    void Start()
    {
       /* spawnees.Sort(SpawnChance.)*/

        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        yield return null;

        while (GameManager.GM.currentLevel == level)
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            float ran = Random.Range(0f, 1f);

            foreach (SpawnChance spawnee in spawnees)
            {
                if (spawnee.spawnChange >= ran)
                {
                    Instantiate(spawnee.spawnee, transform.position, transform.rotation);
                    break;
                }
            }
        }
    }

    [System.Serializable]
    private class SpawnChance
    {
        [SerializeField] internal GameObject spawnee;

        [Range(0f,1f)]
        [SerializeField] internal float spawnChange;
    }

}