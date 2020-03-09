using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    [Header("Stats")]

    [Tooltip("The fire rate of the tower.")]
    [Range(1, 10)]
    public int fireRate;

    [Tooltip("The amount of mana the tower uses once you place it.")]
    [Range(20f, 80f)]
    public int manaUse;

    [Tooltip("The attacking range of the tower.")]
    [Range(1f, 4f)]
    public float attackRadius;

    [Tooltip("The damage the tower does.")]
    [Range(1, 10)]
    public int damage;

    [Tooltip("The max health of the tower.")]
    [Range(5, 20)]
    public int maxHP;

    [Tooltip("The current health of the tower.")]
    [Range(5, 20)]
    public int currentHP;

    public GameObject highlightVersion;

    public virtual void Shoot()
    {

    }
}
