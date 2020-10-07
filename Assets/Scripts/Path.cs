using System;
using UnityEngine;

namespace Opdrachten
{
    public class Path : MonoBehaviour
    {
        [SerializeField] public GameObject[] waypointsArray;
        //public GameObject startPoint;
        public GameObject nextTarget;
        public int waypointIndex = 0;

        public Waypoint GetNextWaypoint()
        {
            //startPoint = GameObject.FindGameObjectWithTag("startPoint");
            waypointsArray = GameObject.FindGameObjectsWithTag("Waypoint");
            nextTarget = waypointsArray[waypointIndex];
            return null;
        }
    }
}