using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Opdrachten;

public class PathShower : Path
{
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _arrivalthreshold = 0.1f;

    private void Start()
    {
        GetNextWaypoint();
    }

    private void Update()
    {
        GetNextWaypoint();
        Vector3 heightOffsetPosition = new Vector3(nextTarget.transform.position.x, transform.position.y, nextTarget.transform.position.z);
        float distance = Vector3.Distance(transform.position, heightOffsetPosition);

        if (distance <= _arrivalthreshold)
        {
            if (waypointIndex == waypointsArray.Length - 1)
            {
                waypointIndex = 0;
                transform.position = waypointsArray[0].transform.position;
            }
            else
            {
                waypointIndex += 1;
            }
        }
        else
        {
            transform.LookAt(heightOffsetPosition);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
