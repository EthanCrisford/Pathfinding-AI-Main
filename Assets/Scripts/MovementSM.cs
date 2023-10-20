using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MovementSM : StateMachine
{
    public float speed;
    public float jumpForce;
    public new Rigidbody rigidbody;
    private float dirX, dirZ;
    public StateMachine sm;

    public Idle idleState;
    public Moving movingState;
    public Jumping jumpingState;
    public Attacking attackingState;

    private void Start()
    {
        sm = gameObject.AddComponent<StateMachine>();

        idleState = new Idle(this,sm);
        movingState = new Moving(this,sm);
        jumpingState = new Jumping(this,sm);
        attackingState = new Attacking(this,sm);
    }
    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public void GetInput()
    {
        dirX = Input.GetAxis("Horizontal") * speed;
        dirZ = Input.GetAxis("Vertical") * speed;
    }

    public void MovePlayer()
    {
        rigidbody.velocity = new Vector3(dirX, rigidbody.velocity.y, dirZ);
    }





    /*
    private void Update()
    {
    }

    public void FixedUpdate()
    {
        rigidbody.velocity = new Vector3 (dirX, rigidbody.velocity.y, dirZ);
    }
    */
}
