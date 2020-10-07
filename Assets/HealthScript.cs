using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    private int PlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 10;
    }

    public void TakeDmg()
    {
        Debug.Log("Take DMG");
        PlayerHealth -= -1;
    }
}
