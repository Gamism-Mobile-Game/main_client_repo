using System;
using System.Collections;
using UnityEngine;

public enum State
{
    Idle,
    Move,
    Attack
}

public class Player : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int Hp;
    [SerializeField] float attackSpeed;
    [SerializeField] GameObject enemy;

    private IState state;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        PlayerStat stat = GetComponent<PlayerStat>();
        stat.Init(damage,attackSpeed,Hp);
        GetComponent<PlayerAttack>().Init(stat);
        PlayerMove playerMove = GetComponent<PlayerMove>();
        playerMove.Init();
        state = playerMove;
        StartCoroutine(OnUpdate());
    }

    private IEnumerator OnUpdate()
    {
        while (true)
        {
            IState getState = state.CheckTransition();
            if(getState != null)  //state°¡ ¹Ù²î¸é true  ¾È¹Ù²î¸é false
            {
                state.ExitState();
                state = getState;
                state.EnterState();
            }
            state.OnUpdate();
            yield return null;
        }
    }
}
