using UnityEngine;
using UnityEngine.AI;

public class RunState : IState
{
    float timer = 0;
    float xVelocity = 1;
    StateMachine sm;

    public void OnEnterState(StateMachine stateMachine)
    {
        sm = stateMachine;
        sm.InitDebugText();

        timer = 0;
    }
    public void UpdateState()
    {
        // Update
        if ( Input.GetKeyDown("i"))
        {
            sm.ChangeState(sm.idleState);
        }
        RunTest(); 
    }

    public void FixedUpdateState()
    {
        // Physics update
        sm.nav.destination = sm.player.transform.position;
    }

    public void OnExitState()
    {
        // Exiting this state
    }

    void RunTest()
    {
        timer += Time.deltaTime;
        if( timer > 2 )
        {
            timer = 0;
            xVelocity = -xVelocity;
        }
    }
}