using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] int level = 4;
    [SerializeField] List<SpawnChance> spawnees;
    [SerializeField] List<SpawnPoint> spawnPoints;
    [SerializeField] int MaxSpawn = 100;
    [Header("Random Min Max")]
    [SerializeField] float ranMin = 1f;
    [SerializeField] float ranMax = 2f;
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
            yield return new WaitForSeconds(Random.Range(ranMin, ranMax));
            float ran = Random.Range(0f, 1f);

            foreach (SpawnChance spawnee in spawnees)
            {
                if (spawnee.spawnChange >= ran)
                {
                    SpawnPoint randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Count)];

                    Instantiate(spawnee.spawnee, 
                        (randomSpawn.point + (Random.insideUnitSphere * randomSpawn.radius)).With(y: randomSpawn.point.y), 
                        transform.rotation);

                    break;
                }
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        foreach (var spawn in spawnPoints)
        {
            Gizmos.DrawCube(spawn.point, new Vector3(1, 1, 1));
            Gizmos.DrawWireSphere(spawn.point, spawn.radius);
        }


    }

    [System.Serializable]
    private class SpawnChance
    {
        [SerializeField] internal GameObject spawnee;

        [Range(0f,1f)]
        [SerializeField] internal float spawnChange;
    }

    [System.Serializable]
    private class SpawnPoint
    {
        [SerializeField] 
        internal Vector3 point;
        [SerializeField] 
        internal float radius = 10; 
    }
}