using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Awake()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
    }
}
