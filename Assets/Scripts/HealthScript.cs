using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private float _currentHealth;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private float _startHealth = 100;
    void Start()
    {   
        _currentHealth = _startHealth;
        _startHealth = _healthSlider.value;
        _fill.color = _gradient.Evaluate(1f);

    }
    private void Update()
    {
        _healthSlider.value = _currentHealth;
        _fill.color = _gradient.Evaluate(_healthSlider.normalizedValue);
    }

    public void TakeDmg()
    {
        if(_currentHealth <= 0)
        {
            Debug.Log("Player is dood");
        }
        else
        {
            _currentHealth -= 1;
        }
    }
}
