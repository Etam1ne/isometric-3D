using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStateFactory
{
    CharStateManager _context;

    public CharStateFactory(CharStateManager currentContext)
    {
        _context = currentContext;
    }

    public CharBaseState Idle()
    {
        return new CharIdleState(_context, this);
    }
    public CharBaseState Movement()
    {
        return new CharMovementState(_context, this);
    }
    public CharBaseState Combat()
    {
        return new CharCombatState(_context, this);
    }
}
