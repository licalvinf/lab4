using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private bool collided;
    public GameObject explosion;
    public GameObject ice;
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (gameObject.name.Contains("Clone"))
            {
                Explode();
                Destroy(gameObject);
            }
        }
    }
    void OnCollisionEnter(Collision co) { 
        if(co.gameObject.tag != "Shootable" && co.gameObject.tag != "Player" && !collided){
            collided = true;
            Explode();
            Destroy(gameObject);
        }
        }
    private void Explode()
    {
        Debug.Log(gameObject.name);
        if(gameObject.name.Equals("newFireball(Clone)")){
            GameObject explodeffect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explodeffect, 1.0f);
        }
        else if(gameObject.name.Equals("IceLance(Clone)"))
        {
            GameObject iceeffect = Instantiate(ice, transform.position, Quaternion.identity);
            Destroy(iceeffect, 1.0f);
        }
        
    }

}
