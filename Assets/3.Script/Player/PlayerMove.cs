using UnityEngine;

public class PlayerMove : MonoBehaviour,IState
{
    public float attackRange;
    private Rigidbody2D rigid;
    private IState attackState;
    public void Init()
    {
       rigid = GetComponent<Rigidbody2D>();
    }

    public void EnterState()
    {
        rigid.linearVelocityX = 1;
    }

    public void ExitState()
    {
        rigid.linearVelocityX = 0;
    }

    public void OnUpdate()
    {

    }

    public IState CheckTransition()
    {
        Collider2D col = Physics2D.OverlapBox(transform.position + new Vector3(attackRange / 2, 0), new Vector3(attackRange, attackRange), 0);

        if (col != null)
            return attackState;
        else
            return null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(attackRange/2,0),new Vector3(attackRange, attackRange));
    }
}
