/*NPCMove.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    GameObject target;
    NavMeshAgent navAgent;

    public void Start()
    {
        target = GameObject.Find("Player");
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        Vector3 navPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        if(navAgent.destination != target.transform.position)
        {
            navAgent.SetDestination(navPos);
        }
        else
        {
            navAgent.SetDestination(transform.position);
        }
    }
}