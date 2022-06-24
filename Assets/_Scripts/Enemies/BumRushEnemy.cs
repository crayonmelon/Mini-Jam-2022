using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BumRushEnemy : MonoBehaviour
{
    NavMeshAgent agent;

    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0,0,0);
        agent.SetDestination(target.position);
    }
}