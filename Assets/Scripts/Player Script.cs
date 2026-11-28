using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerScript : CharacterScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform playerModel;
    public float speed = 3;
    public Rigidbody rb;
    public List<GameObject> guns;
    public int gunIndex;
    public int currentGun;
    void Start()
    {
        currentSpeed = speed;
        foreach(GameObject guns in guns)
        {
            guns.SetActive(false);
        }
        guns[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;
        Vector3 forward = playerModel.forward;
        Vector3 right = playerModel.right;
        if (Keyboard.current.wKey.isPressed)
        {
            move += forward;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            move -= forward;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            move -= right;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            move += right;
        }
        rb.linearVelocity = move.normalized * currentSpeed;

        if(Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            WeaponSwitch(0);
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            WeaponSwitch(1);
        }
        
    }

    void WeaponSwitch(int gunIndex)
    {
        if(gunIndex < 0 || gunIndex >= guns.Count || gunIndex == currentGun)
        {
            return;
        }
        foreach(GameObject guns in guns)
        {
            guns.SetActive(false);
        }
        currentGun = gunIndex;
        guns[currentGun].SetActive(true);
    }
}
