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
        state = playerMove.GetComponent<IState>();
        StartCoroutine(OnUpdate());
    }

    private IEnumerator OnUpdate()
    {
        while (true)
        {
            state.CheckTransition();
            state.OnUpdate();
            yield return null;
        }
    }
}
