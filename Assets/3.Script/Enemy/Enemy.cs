using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHp;
    [SerializeField] float speed;
    [SerializeField] float attackRange;
    [SerializeField] float attackSpeed;
    IState state;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        EnemyStat stat = GetComponent<EnemyStat>();
        stat.Init(0, attackSpeed, attackRange, maxHp, speed);
        EnemyMove enemyMove = GetComponent<EnemyMove>();
        GetComponent<EnemyAttack>().Init(stat);
        enemyMove.Init();
        state = enemyMove;
        StartCoroutine(OnUpdate());
    }

    private IEnumerator OnUpdate()
    {
        while (true)
        {
            IState getState = state.CheckTransition();
            if (getState != null)  //state°¡ ¹Ù²î¸é true  ¾È¹Ù²î¸é false
            {
                state.ExitState();
                state = getState;
                state.EnterState();
            }
            state.OnUpdate();
            yield return null;
        }
    }

    public void Die()
    {
        Debug.Log("Á×À½");
    }
}
