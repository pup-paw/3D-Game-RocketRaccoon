/*MainCamera_Action.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    GameObject player;
    public float offsetX = 0f;
    public float offsetY = 3f;
    public float offsetZ = -8f;

    Vector3 cameraPosition;
    public float followSpeed = 2f;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        moveObjectFunc();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);
    }

    private float speed_rota = 2.0f;
    void moveObjectFunc()
    {
        //float mouseX = Input.GetAxis("Mouse X") % 180;
        float mouseY = Input.GetAxis("Mouse Y") % 180;
        //transform.Rotate(Vector3.up * speed_rota * mouseX);
        transform.Rotate(Vector3.left * speed_rota * mouseY);
    }
}
