using System;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public int Damage { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }

    public virtual void Init(int damage,float attackSpeed, float attackRange)
    {
        Damage = damage;
        AttackSpeed = attackSpeed;
        AttackRange = attackRange;
    }
}
