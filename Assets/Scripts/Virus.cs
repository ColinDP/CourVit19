using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(NavMeshAgent))]
public class Virus : MonoBehaviour
{

    private GameObject target;
    public static GameObject[] players;
    private NavMeshAgent _agent;
    private Rigidbody rb;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("player");
        target = players[0];
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_agent.isActiveAndEnabled)
        {
            MoveToTarget();
        }
        
    }
    
    private void MoveToTarget()
    {
        _agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            
            StartCoroutine(DisableNavmesh());
        }
    }

    IEnumerator DisableNavmesh()
    {
        _agent.enabled = false;
        yield return new WaitForSeconds((float)1);
        rb.velocity = Vector3.zero;
        _agent.enabled = true;
    }

}
