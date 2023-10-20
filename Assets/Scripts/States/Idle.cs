using UnityEngine;

public class Idle : BaseState
{
    private float _horizontalInput;

    public Idle(MovementSM player, StateMachine sm) : base(player, sm)
    {

    }

    public override void Enter()
    {
        base.Enter();
        //sm.spriteRenderer.color = Color.black;
        _horizontalInput = 0f;

        Debug.Log("entering idle state");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exiting Idle");
    }

    public override void UpdateLogic()
    {
        Debug.Log(Mathf.Epsilon);
        base.UpdateLogic();

        //base.MovePlayer();

        //if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
        //stateMachine.ChangeState(sm.movingState);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(sm.attackingState);
        }
    }
}
