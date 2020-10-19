using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTargetTower : Tower
{
    private Enemy[] _enemies;
    private bool waited = true;
    [SerializeField] private float _fireRate = 0.4f;
    [SerializeField] private float _damage = 10f;

    protected override bool CanAttack()
    {
        _enemies = _rangeChecker.GetAllEnemiesInRange();
        if (_enemies != null)
        {
            if(_enemies.Length >= 1)
            {
                return true;
            }
        }
        return false;
    }

    protected override void Attack()
    {
        foreach(var enemy in _enemies)
        {
            if (CanAttack() == true && waited == true)
            {
                StartCoroutine(WaitForShot());
                waited = false;
                enemy.GetComponent<Enemy>().TakeDmg(_damage);
                //Debug.Log("Val deze vijand aan: " + enemy.name);
            }
        }
    }
    protected IEnumerator WaitForShot()
    {
        yield return new WaitForSeconds(_fireRate);
        waited = true;
    }
}
