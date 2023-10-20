using UnityEngine;

public class Grounded : BaseState
{
    protected MovementSM sm;

    public Grounded(MovementSM player, StateMachine sm) : base(player, sm)
    {
        //sm = (MovementSM) this.stateMachine;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(sm.jumpingState);
    }

}
