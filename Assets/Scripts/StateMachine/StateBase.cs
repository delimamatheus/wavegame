using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
    public virtual void OnStateEnter(object o = null)
    {
       // Debug.Log("Enter");
    }

    public virtual void OnStateStay(object o = null)
    {
       // Debug.Log("Stay");
    }

    public virtual void OnStateExit(object o = null)
    {
       // Debug.Log("Exit");
    }
}

public class StateMoving : StateBase
{
    public Player player;
    public override void OnStateEnter(object o = null)
    {
        player = (Player)o;
        player.canMove = true;

        base.OnStateEnter(o);
    }

    public override void OnStateExit(object o = null)
    {
        player.canMove = false;
        base.OnStateExit(o);
    }
}
