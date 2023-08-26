using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject enemyObject, patrolPointsObject;
    [SerializeField] private float speed = 3f;
    private Transform[] patrolPoints; //Set in inspector
    private int targetPointIndex = 0;
    

    void Start()
    {
        // Find all child patrol points
        patrolPoints = new Transform[patrolPointsObject.transform.childCount];
        for (int i = 0; i < patrolPointsObject.transform.childCount; i++)
        {
            patrolPoints[i] = patrolPointsObject.transform.GetChild(i);
        }
    }

    void Update()
    {
        PatrolPlatform();
    }

    void PatrolPlatform()
    {
        if (patrolPoints.Length == 0) return;

        var targetPoint = patrolPoints[targetPointIndex].position;
        var movementStep = speed * Time.deltaTime;

        enemyObject.transform.position = Vector2.MoveTowards(enemyObject.transform.position, targetPoint, movementStep);

        if (Vector2.Distance(enemyObject.transform.position, targetPoint) < 0.1f)
        {
            // If reached the current target point, move towards the next point
            targetPointIndex = (targetPointIndex + 1) % patrolPoints.Length;
        }
    }
}
