using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _startHealth = 100;
    void Start()
    {
        _currentHealth = _startHealth;
        _startHealth = _hpSlider.value;
    }
    private void Update()
    {
        _hpSlider.value = _currentHealth;

        if(_currentHealth <= 0)
        {
            Debug.Log("Ik ben dood");
            Destroy(gameObject);
        }
    }

    public void TakeDmg(float dmg)
    {       
        _currentHealth -= dmg;
    }
}
