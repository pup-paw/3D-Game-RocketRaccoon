using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rgbody;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction, float force)
    {
        rgbody.AddForce(direction * force);
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 10.0f)
        {
            Destroy(gameObject);
        }
    }
}
