// Adpated from https://gamedevbeginner.com/state-machines-in-unity-how-and-when-to-use-them/
using UnityEngine;
using UnityEngine.AI;

public interface IState
{
    public void UpdateState();
    public void FixedUpdateState();
    public void OnEnterState(StateMachine sm);
    public void OnExitState();
}

public class StateMachine : MonoBehaviour
{
    // attach this script to your player or enemy object that requires a state machine
    public IState currentState, lastState;
    public IdleState idleState = new IdleState();
    public RunState runState = new RunState();
    Rigidbody rb;

    // debug text
    public string text;
    private NavMeshAgent nav;
    private int destPoint;
    public Animator anim;
    public GameObject player;

    private void Start()
    {
        text = "";  // clear debug text

        rb = GetComponent<Rigidbody>();

        lastState = null;
        // this is the inital state
        ChangeState(idleState);

        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }

        if (!nav.pathPending)
        {
            anim.SetBool("Walk", true);
        }
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedUpdateState();
        }

        nav.destination = player.transform.position;

    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }
        lastState = currentState;
        currentState = newState;
        currentState.OnEnterState(this);
    }

    public IState GetState()
    {
        return currentState;
    }

    // Debug Text Draw - draws the string 'text' to the canvas
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10f, 10f, 1600f, 1600f));
        GUILayout.Label($"<color=white><size=24>{text}</size></color>");
        GUILayout.EndArea();
    }

    public void ExampleSharedMethod()
    {
        // this in an example method that can be shared by any state
    }

    public void MoveSprite( float xv, float yv )
    {
        rb.velocity = new Vector3(xv, yv, 0);
    }

    public void InitDebugText()
    {
        string lastStateText;
        string currentStateText = currentState.ToString();

        if (lastState != null)
            lastStateText = lastState.ToString();
        else
            lastStateText = "null";
        text = $"Current State = {currentStateText}\nLast state was {lastStateText}\nPress R to change to Run state\nPress I to change to Idle state";

        
    }
}
