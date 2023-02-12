using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharMovementState : CharBaseState 
{
    public CharMovementState(CharStateManager currentContext, CharStateFactory charStateFactory)
    : base(currentContext, charStateFactory) { }
    public override void AwakeState()
    {

    }
    public override void EnterState()
    {
        Debug.Log("Moving");
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void FixedUpdateState()
    {
        if (!_ctx.IsAnimating)
        {
            _ctx.Rb.velocity = new Vector3(_ctx.Inputs.x * _ctx.Speed, _ctx.Rb.velocity.y, _ctx.Inputs.z * _ctx.Speed);
            _ctx.MovementAnimation();
            _ctx.RotateCharacter();
        }
    }
    public override void EndState()
    {
        _ctx.Animator.SetInteger("Direction", 0);
    }
    public override void CheckSwitchStates()
    {
        if (_ctx.Inputs == Vector3.zero) SwitchState(_factory.Idle());
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            Debug.Log("Start combat");
            SwitchState(_factory.Combat());
        }
    }
}
