using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Camera cam;
    public GameObject fireball;
    public GameObject icelance;
    public Transform firepoint;
    public float projForce = 300f;
    public float range = 100f;
    public GameObject wandflare;

    private float fireRate = 2.0f;
    private float nextFire = -1f;
    public GameObject firesound;
    public GameObject icesound;

    private Vector3 destination;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
            return;
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                wandFlare();
                LaunchProj("Fireball");
                nextFire = fireRate;
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                wandFlare();
                LaunchProj("Icelance");
                nextFire = fireRate;
            }
        }

    }
    void wandFlare()
    {
        GameObject flareeffect = Instantiate(wandflare, firepoint.position, Quaternion.identity);
        Destroy(flareeffect, 1.0f);
    }

    void LaunchProj(string projtype)
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);
        Vector3 direction = targetPoint - firepoint.position;
        if (projtype.Equals("Fireball")){
            var fireballobj = Instantiate(fireball, firepoint.position, Quaternion.identity) as GameObject;
            fireballobj.GetComponent<Rigidbody>().AddForce(direction.normalized * projForce);
            firesound.GetComponent<AudioSource>().Play();
        }
        else if (projtype.Equals("Icelance"))
        {
            var icelanceobj = Instantiate(icelance, firepoint.position, Quaternion.identity) as GameObject;
            icelanceobj.transform.LookAt(targetPoint);

            icelanceobj.GetComponent<Rigidbody>().AddForce(direction.normalized * projForce);
            icesound.GetComponent<AudioSource>().Play();
        }
    }


}
