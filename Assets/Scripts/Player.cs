using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Vector3 _currentVelocity;
    private NavMeshAgent _agent;
    private RaycastHit hit;
    private NavMeshHit navmeshhit;

    public bool Invincible { get; set; }

    public float Speed
    {
        get => GetComponent<NavMeshAgent>().speed;
        set => GetComponent<NavMeshAgent>().speed = value;
    }

    private void Awake()
    {
        Invincible = false;
    }
    private void Update()
    {
        // Move();
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horInput, 0f, verInput);
        Vector3 moveDestination = transform.position + movement;
        GetComponent<NavMeshAgent>().destination = moveDestination;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("person"))
        {
            Vector3 origin = transform.localPosition;
            Vector3 direction = other.transform.localPosition;
            if (!NavMesh.Raycast(origin, direction, out navmeshhit, NavMesh.AllAreas))
            {
                if(!Invincible)
                    gameObject.GetComponent<Rigidbody>().GetComponent<IDeath>()?.OnDeath();
            }
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     StartCoroutine(DangerZone());
    // }
    //
    // IEnumerator DangerZone()
    // {
    //     yield return new WaitForSeconds((float)2);
    //     GameManager.GameManager.Instance.LoadScene("GameOver");
    // }
}