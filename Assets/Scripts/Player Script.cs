using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : CharacterScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform cameraPivot;
    public Transform playerModel;
    public float speed = 3;
    public Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = cameraPivot.forward;
        Vector3 right = cameraPivot.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        currentSpeed = speed;

        Vector3 direction = Vector3.zero;
        Vector3 vel = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            direction += forward;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            direction -= right;  
        }
        if (Keyboard.current.sKey.isPressed)
        {
            direction -= forward;   
        }
        if (Keyboard.current.dKey.isPressed)
        {
            direction += right;
        }


        playerModel.rotation = Quaternion.LookRotation(forward);
        vel = direction.normalized * currentSpeed;
        rb.linearVelocity = vel;
    }
}
