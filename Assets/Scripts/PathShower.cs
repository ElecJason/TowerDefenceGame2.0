using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Opdrachten;

public class PathShower : Path
{
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _arrivalthreshold = 0.1f;
    [SerializeField] private TrailRenderer trailRenderer;

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
                trailRenderer.enabled = false;
                waypointIndex = 0;
                transform.position = waypointsArray[0].transform.position;
                trailRenderer.Clear();
                trailRenderer.enabled = true;
            }
            else
            {
                //Debug.DrawLine(waypointsArray[waypointIndex].transform.position, waypointsArray[waypointIndex + 1].transform.position, Color.magenta, Mathf.Infinity);
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
