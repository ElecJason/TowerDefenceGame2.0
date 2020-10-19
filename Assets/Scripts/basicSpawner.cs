using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private bool waited = true;

    private void Awake()
    {
        waited = true;

    }


    void Update()
    {
        if(waited == true)
        {
            Instantiate(enemyPrefab, transform);
            waited = false;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        waited = true;
    }
}
