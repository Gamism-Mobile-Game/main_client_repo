using UnityEngine;

public class PlayerAttack : MonoBehaviour,IState
{
    private int damage;
    private float attackSpeed;
    private float attackRange;

    private float curTime = 0;
    private IState moveState;

    private IGetDamage enemy;

    public void Init(PlayerStat stat)
    {
        damage = stat.Damage;
        attackSpeed = stat.AttackSpeed;
        attackRange = stat.AttackRange;
        moveState = GetComponent<PlayerMove>();
    }

    private void Attack()
    {
        if (enemy == null)
        {
            enemy = GetTarget();
            if (enemy == null)
                return;
        }
        if (curTime <= 0)
        {
            Debug.Log("АјАн");
            enemy.Hp -= damage;
            curTime = attackSpeed;
        }
        else
            curTime -= Time.deltaTime;
    }

    public void EnterState()
    {
        enemy = GetTarget();
    }

    public void ExitState()
    {
        enemy = null;
    }

    private IGetDamage GetTarget()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position + new Vector3(attackRange/2, 0), new Vector3(attackRange, attackRange), 0);
        foreach (Collider2D col in cols)
        {
            if (col.TryGetComponent<EnemyStat>(out var enemy))
                return enemy.GetComponent<IGetDamage>();
        }
        return null;
    }

    public void OnUpdate()
    {
        Attack();
    }

    public IState CheckTransition()
    {
        if (GetTarget() == null)
            return moveState;
        else
            return null;
    }
}
