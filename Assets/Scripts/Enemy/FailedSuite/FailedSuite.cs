using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedSuite : EnemyController
{
    [SerializeField] private EnemyDataScriptableObject classData;


    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        currentHealth = classData.health;
        enemyMoveSpeed = classData.speed;
        damageAmount = classData.damage;
        attackCooldown = classData.attackCooldown;
    }


}
