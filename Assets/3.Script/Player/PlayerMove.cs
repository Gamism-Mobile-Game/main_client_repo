using UnityEngine;

public class PlayerMove : MonoBehaviour,IState
{
    public float moveSpeed;
    public float attackRange;
    private Rigidbody2D rigid;
    private IState attackState;
    public void Init()
    {
       rigid = GetComponent<Rigidbody2D>();
        attackState = GetComponent<PlayerAttack>();
    }

    public void EnterState()
    {
       
    }

    public void ExitState()
    {
        rigid.linearVelocityX = 0;
    }

    public void OnUpdate()
    {
        rigid.linearVelocityX = moveSpeed;
    }

    public IState CheckTransition()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position + new Vector3(attackRange / 2, 0), new Vector3(attackRange, attackRange), 0);
        foreach (Collider2D col in cols)
        {
            if (col.TryGetComponent<EnemyStat>(out _))
                return attackState;
        }
        return null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(attackRange/2,0),new Vector3(attackRange, attackRange));
    }
}
