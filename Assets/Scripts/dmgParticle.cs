using System.Collections;
using System.Collections.Generic;
using Opdrachten;
using UnityEngine;
using UnityEngine.Events;

public class dmgParticle : Path
{
    [SerializeField] private GameObject dmgParticlePrefab;
    [SerializeField] private Transform lastWayPoint;

    public void spawnNew()
    {
        GameObject clone = (GameObject)Instantiate(dmgParticlePrefab, lastWayPoint);
        Destroy(clone, 3);
    }
}
