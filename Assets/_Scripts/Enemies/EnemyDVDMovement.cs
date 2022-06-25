using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDVDMovement : MonoBehaviour
{
    [SerializeField] float BoundsLeft = 0;
    [SerializeField] float BoundsRight = 0;
    [SerializeField] float BoundsUp = 0;
    [SerializeField] float BoundsDown = 0;

    [SerializeField] float speed = 2;
    private Vector3 Direction;

    void Start()
    {
        Direction = new Vector3(1, Random.Range(-1, 2), 0);
    }

    void Update()
    {
        transform.Translate(Direction * Time.deltaTime* speed);
        
        if (transform.position.x < BoundsLeft)
        {
            Direction = new Vector3(1, Random.Range(-1f, 1f), 0);
        }
        else if (transform.position.x > BoundsRight)
        {
            Direction = new Vector3(-1, Random.Range(-1f, 1f), 0);
        }
        else if (transform.position.z < BoundsUp)
        {
            Direction = new Vector3(Random.Range(-1f, 1f), 1, 0);
        }
        else if (transform.position.z > BoundsDown)
        {
            Direction = new Vector3(Random.Range(-1f, 1f), -1, 0);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Vector3 TopLeft = new Vector3(BoundsLeft, transform.position.y, BoundsUp);
        Vector3 TopRight = new Vector3(BoundsRight, transform.position.y, BoundsUp);
        Vector3 BottomLeft = new Vector3(BoundsLeft, transform.position.y, BoundsDown);
        Vector3 BottomRight = new Vector3(BoundsRight, transform.position.y, BoundsDown);

        Gizmos.DrawLine(TopLeft, TopRight);
        Gizmos.DrawLine(TopLeft, BottomLeft);
        Gizmos.DrawLine(TopRight, BottomRight);
        Gizmos.DrawLine(BottomLeft, BottomRight);

    }
}
