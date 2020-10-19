using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform cam;

    private void Awake()
    {
        if(cam = null)
        {
            cam = Camera.main.transform;
        }
    }
    private void LateUpdate()
    {

    }

}
