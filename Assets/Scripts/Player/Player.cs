using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;

    private float horizontal;
    private float vertical;
    public float speed;

    Vector3 moveDir;
 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveDir = transform.forward * vertical + transform.right * horizontal;

        characterController.Move(moveDir * speed);
    }
}
