using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponsScript : ObjectScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damage;
    public float fireRate;
    public float fireCD;
    public float range;
    public int magCap;
    public int ammo;
    public float reloadTime;
    public ParticleSystem muzzleFlash;
    public Transform muzzle;
    public LineRenderer bulletTrail;

    public Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Weapon Update Running");
        fireCD -= Time.deltaTime;
        if(Mouse.current.leftButton.isPressed && ammo > 0 && fireCD <= 0)
        {
            //Debug.Log("Weapon Firing");
            Fire();
            ammo--;
            fireCD = 1f / fireRate;
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Reload();
        }
    }

    protected virtual void Fire()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range))
        {
            bulletTrail.enabled = true;
            bulletTrail.SetPosition(0, muzzle.transform.position);
            bulletTrail.SetPosition(1, hit.point);
            StartCoroutine(HideBulletTrail());
            muzzleFlash.Play();
            Debug.Log(hit.transform.name);
        }
        
    }

    protected virtual void Reload()
    {
        ammo = magCap;
    }

    protected virtual IEnumerator HideBulletTrail()
    {
        yield return new WaitForSeconds(0.1f);
        bulletTrail.enabled = false;

    } 
}
