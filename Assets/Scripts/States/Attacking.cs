using System.Threading;
using UnityEditorInternal;
using UnityEngine;

public class Attacking : BaseState
{

    private float idleTimer;

    protected MovementSM sm;

    public Attacking(MovementSM player, StateMachine sm) : base(player, sm)

    {
        //sm = (MovementSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        //sm.spriteRenderer.color = Color.blue;

        idleTimer = 1f;

        Debug.Log("Entering attack");

        //Invoke("BackToIdle", 1);

        //StartCoroutine(BackToIdle()); 
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exiting Attacking");
    }

    public override void UpdateLogic()
    {
       base.UpdateLogic();

        idleTimer -= Time.deltaTime; 
        if (idleTimer < 0f)
        {
            stateMachine.ChangeState(sm.idleState);
        }

        /*if (!Input.anyKey)
        {
            stateMachine.ChangeState(sm.idleState);
        }*/
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
