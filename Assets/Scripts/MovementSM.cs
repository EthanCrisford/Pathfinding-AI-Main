using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    public float speed;
    public float jumpForce;
    public new Rigidbody rigidbody;
    private float dirX, dirZ;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal") * speed;
        dirZ = Input.GetAxis("Vertical") * speed;
    }

    public void FixedUpdate()
    {
        rigidbody.velocity = new Vector3 (dirX, rigidbody.velocity.y, dirZ);
    }
}
