using UnityEngine;

public interface IState
{
    public void EnterState();

    public void OnUpdate();

    public void ExitState();

    public IState CheckTransition();
}
