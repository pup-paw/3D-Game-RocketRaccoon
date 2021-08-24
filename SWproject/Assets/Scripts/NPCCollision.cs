/*NPCCollision.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
            Debug.Log(player.health);
        }
    }
}
