using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public enum EnemyTypes
    {
        Ranged,
        Melee
    }

    [Header("Stats")]

    [Tooltip("The damage the enemy does.")]
    [Range(1, 10)]
    public int damage;

    [Tooltip("The max health of the enemy.")]
    [Range(5, 20)]
    public int maxHP;

    [Tooltip("The current health of the enemy.")]
    [Range(5, 20)]
    public int currentHP;

    [Tooltip("The enemy type.")]
    public EnemyTypes enemyType;

    public virtual void Attack()
    {

    }
}
