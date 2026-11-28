using System.Collections;
using UnityEngine;

public class ShotgunScript : WeaponsScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LineRenderer[] bulletTrails;


    void Start()
    {
        
    }


    protected override void Fire()
    {
        //Debug.Log("Shotgun fired!");
        for (int i = 0;  i < 10; i++)
        {
            Vector3 spread = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            Vector3 direction = cam.transform.forward + cam.transform.right * spread.x + cam.transform.up * spread.y;
            direction.Normalize();
            if (Physics.Raycast(cam.transform.position, direction, out RaycastHit hit, range))
            {
                bulletTrails[i].enabled = true;
                bulletTrails[i].SetPosition(0, muzzle.position);
                bulletTrails[i].SetPosition(1, hit.point);
                StartCoroutine(HideBulletTrail(bulletTrails[i]));
                muzzleFlash.Play();
                Debug.Log(hit.transform.name);
            }
        }
        
    }

    IEnumerator HideBulletTrail(LineRenderer trail)
    {
        yield return new WaitForSeconds(0.1f);
        trail.enabled = false;
    }
}
