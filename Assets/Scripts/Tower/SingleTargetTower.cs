using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetTower : Tower
{
    private Enemy _target;
    private bool waited = true;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _damage = 25f;

    protected override bool CanAttack()
    {
        _target = _rangeChecker.GetFirstEnemyInRange();
        return _target != null;
    }

    protected override void Attack()
    {
        if(CanAttack() == true && waited == true)
        {
            StartCoroutine(WaitForShot());
            waited = false;
            _target.GetComponent<Enemy>().TakeDmg(_damage);
            //Debug.Log("I attacked this many times");
        }
    }

    protected IEnumerator WaitForShot()
    {
        yield return new WaitForSeconds(_fireRate);
        waited = true;
    }
}
