using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCombatState : CharBaseState
{
    public CharCombatState(CharStateManager currentContext, CharStateFactory charStateFactory)
    : base(currentContext, charStateFactory) { }

    private CharCoroutines _coroutines;
    private int _attackCount;

    public override void AwakeState()
    {
        _coroutines = _ctx.Character.GetComponent<CharCoroutines>();
    }
    public override void EnterState()
    {
        Debug.Log("Combating");
    }
    public override void UpdateState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_attackCount > 1) _attackCount = 0;
            _attackCount++;
            _ctx.Animator.SetTrigger($"Attack{_attackCount}");
        }

        if (Input.GetKeyDown(KeyCode.L)) CheckSwitchStates();
    }
    public override void FixedUpdateState()
    {
        if (_ctx.IsAnimating)
        {
            _ctx.Rb.velocity = Vector3.zero;
        }
        else
        {
            _ctx.Rb.velocity = new Vector3(_ctx.Inputs.x * _ctx.Speed, _ctx.Rb.velocity.y, _ctx.Inputs.z * _ctx.Speed);
            _ctx.MovementAnimation();
            _ctx.RotateCharacter();
        }
    }
    public override void EndState()
    {

    }
    public override void CheckSwitchStates()
    {
        SwitchState(_factory.Idle());
    }
}
