/*Bullet.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool isFire;
    Vector3 direction;
    [SerializeField]
    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isFire)
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    public void Fire(Vector3 dir)
    {
        direction = dir;
        isFire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        NPCMove npc = other.GetComponent<NPCMove>();
        if(npc!=null)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameController.instance.leftAlien --;
            Debug.Log(GameController.instance.leftAlien);
            GameController.instance.UpdateScore();
        }
    }
}
