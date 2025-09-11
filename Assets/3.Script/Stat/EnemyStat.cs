using System;
using UnityEngine;

public class EnemyStat : Stat,IGetDamage
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

    public float Speed { get; set; }

    protected Action getDamageAction;

    

    public void Init(int damage, float attackSpeed,float attackRange, int maxHp,float speed)
    {
        base.Init(damage, attackSpeed,attackRange);
        MaxHp = maxHp;
        Hp = maxHp;
        Speed = speed;
    }
}
