using System;
using UnityEngine;

public class PlayerStat : Stat,IGetDamage
{
    public int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
        }
    }

    public int MaxHp { get; set; }
    public float AttackRange;

    private int hp;

    protected Action getDamageAction;


    public void Init(int damage, float attackSpeed, int maxHp)
    {
        base.Init(damage, attackSpeed);
        MaxHp = maxHp;
        Hp = maxHp;
    }
}
