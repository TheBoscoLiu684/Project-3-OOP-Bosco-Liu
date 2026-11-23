using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponsScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damage;
    public float range;
    public Camera cam;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.isPressed)
        {
            Fire();
        }
    }

    void Fire()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.transform.name);
        }
        
    }
}
