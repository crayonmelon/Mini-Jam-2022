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
    [SerializeField] int bulkSpawnSize = 4;

    [Header("Random Min Max")]
    [SerializeField] float ranMin = 1f;
    [SerializeField] float ranMax = 2f;
    void OnEnable()
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

            if (MaxSpawn < GameManager.GM.GetEnemyCount(level))
                continue;

            float ran = Random.Range(0f, 1f);
            for (int i = 0; i < Random.Range(1, bulkSpawnSize); i++)
            {

                SpawnPoint randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Count)];

                foreach (SpawnChance spawnee in spawnees)
                {
                    if (spawnee.spawnChange >= ran)
                    {
                        Instantiate(spawnee.spawnee, 
                            (randomSpawn.point + (Random.insideUnitSphere * randomSpawn.radius)).With(y: randomSpawn.point.y), 
                            transform.rotation);

                        break;
                    }
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