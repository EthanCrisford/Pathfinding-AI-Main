using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState 
{

    protected StateMachine stateMachine;
    protected MovementSM player;
    
    public BaseState(MovementSM player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() {}
    public virtual void UpdateLogic() {}
    public virtual void UpdatePhysics() {}
    public virtual void Exit() {}
}
