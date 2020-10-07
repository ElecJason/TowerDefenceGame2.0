using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected EnemyInRangeChecker _rangeChecker;    

    private void Awake()
    {
        _rangeChecker = GetComponent<EnemyInRangeChecker>();
    }

    private void Update()
    {
        if (!CanAttack()) return;
            Attack();
    }

    protected virtual bool CanAttack()
    {
        return false;
    }

    protected virtual void Attack() {}
}
