using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody rigidbody;
    public GameObject bullet;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction, float force)
    {
        rigidbody.AddForce(direction * force);
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 500.0f)
        {
            Destroy(gameObject);
        }
    }

}
