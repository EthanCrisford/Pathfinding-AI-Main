using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed;

    private Transform target;

    void Awake()
    {
        target = transform;
        target.transform.position = transform.position;
    }

    void Start()
    {
        
    }

    void Update()
    {
        var move = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, move);
    }
}
