using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTrigger : MonoBehaviour
{
    private Road road;
    private TrainMovement trainMovement;

    private void Awake()
    {
        trainMovement = GetComponent<TrainMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        road = collision.gameObject.GetComponent<Road>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var triggerPoint = road.transform.Find(TagManager.TRIGGERPOINT);

        if (triggerPoint)
        {
            trainMovement.desiredDirection = road.currentDirection;
        }
    }
}
