using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    [Header("Stats")]

    [Tooltip("The fire rate of the tower.")]
    [Range(1f, 5f)]
    public float fireRate;

    [Tooltip("The amount of mana the tower uses once you place it.")]
    [Range(20f, 80f)]
    public float manaUse;

    [Tooltip("The attacking range of the tower.")]
    [Range(1f, 4f)]
    public float attackRadius;

    [Tooltip("The damage the tower does.")]
    [Range(1f, 10f)]
    public float damage;

    [Tooltip("The health of the tower.")]
    [Range(5f, 20f)]
    public float health;

    public virtual void Shoot()
    {

    }
}
