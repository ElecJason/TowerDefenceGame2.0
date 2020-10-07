using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float health = 10;
    [SerializeField] private float _startHealth = 100;
    void Start()
    {
        _currentHealth = _startHealth;
        _startHealth = _hpSlider.value;
    }
    private void Update()
    {
        _hpSlider.value = _currentHealth;
    }

    public void TakeDmg()
    {       
        _currentHealth -= 10;
    }
}
