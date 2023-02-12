using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharIdleState : CharBaseState
{
    public CharIdleState(CharStateManager currentContext, CharStateFactory charStateFactory)
    : base(currentContext, charStateFactory) { }
    public override void AwakeState()
    {

    }
    public override void EnterState()
    {
        Debug.Log("Idling");
        _ctx.Rb.velocity = Vector3.zero;
        _ctx.Animator.SetInteger("Direction", 0);
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void FixedUpdateState()
    {
        _ctx.RotateCharacter();
    }
    public override void EndState()
    {

    }
    public override void CheckSwitchStates()
    {
        if (_ctx.Inputs != Vector3.zero) SwitchState(_factory.Movement());
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Start combat");
            SwitchState(_factory.Combat());
        }
    }
}
