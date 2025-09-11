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

    private int hp;

    protected Action getDamageAction;


    public void Init(int damage, float attackSpeed,float attackRange, int maxHp)
    {
        base.Init(damage, attackSpeed,attackRange);
        MaxHp = maxHp;
        Hp = maxHp;
    }
}
