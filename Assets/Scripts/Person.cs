using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class Person : MonoBehaviour
{
    private Transform[] _checkpoints;
    private int _index;
    private NavMeshAgent _agent;
    private GameObject checkpointsContainer;

    private void Awake()
    {
        checkpointsContainer = GameObject.FindWithTag("checkpoint");
        _checkpoints = GetChildren(checkpointsContainer.transform);
        _index = GetRandomPath();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(_checkpoints[_index].gameObject))
        {
            _index = GetRandomPath();
            Move();
        }
    }

    private void Move()
    {
        _agent.SetDestination(_checkpoints[_index].position);
    }

    private int GetRandomPath()
    {
        int i;
        do
        {
            i = Mathf.Abs((int)DateTime.Now.Ticks - GetInstanceID()) % _checkpoints.Length;
        } while (i == _index);
        return i;
    }

    private Transform[] GetChildren(Transform t)
    {
        List<Transform> result = new List<Transform>(60);
        foreach (Transform child in t)
        {
            result.Add(child);
        }
        return result.ToArray();
    }
}