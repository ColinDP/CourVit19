using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerVirus : MonoBehaviour
{
    [SerializeField] private GameObject virusObject;
    [SerializeField] private GameObject virusClone;
    [SerializeField] private int numberOfViruses;
    [SerializeField] private int timeBetweenInstantiate;


    private void Start()
    {
        StartCoroutine(InstantiateViruses());
    }
    
    private IEnumerator InstantiateViruses()
    {
        for (int i = 0; i < numberOfViruses; i++)
        {
            virusClone = Instantiate(virusObject);
            virusClone.transform.parent = gameObject.transform;
            virusClone.GetComponent<NavMeshAgent>().Warp(gameObject.transform.position);
            yield return new WaitForSeconds(timeBetweenInstantiate);
        }  
    }
}
