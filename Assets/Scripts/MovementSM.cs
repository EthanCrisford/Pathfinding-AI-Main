using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    public float speed;
    public float jumpForce;
    public new Rigidbody rigidbody;
    private float dirX, dirZ;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public Jumping jumpingState;
    [HideInInspector]
    public Attacking attackingState;

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jumping(this);
        attackingState = new Attacking(this);

        rigidbody = GetComponent<Rigidbody>();
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizzontal") * speed;
        dirZ = Input.GetAxis("Vertical") * speed;
    }

    public void FixedUpdate()
    {
        rigidbody.velocity = new Vector3 (dirX, rigidbody.velocity.y, dirZ);
    }
}
