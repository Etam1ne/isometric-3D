using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharBaseState
{
    protected CharStateManager _ctx;
    protected CharStateFactory _factory;
    public CharBaseState(CharStateManager currentContext, CharStateFactory charStateFactory)
    {
        _ctx = currentContext;
        _factory = charStateFactory;
    }

    public abstract void AwakeState();
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void EndState();
    public abstract void CheckSwitchStates();

    protected void SwitchState(CharBaseState newState)
    {
        EndState();
        newState.AwakeState();

        newState.EnterState();

        _ctx.CurrentState = newState;
    }
}
