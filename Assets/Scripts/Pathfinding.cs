using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] points;

    private NavMeshAgent nav;
    private int destPoint;
    public Animator anim;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    void Update()
    {
       if (!nav.pathPending)
        {
            anim.SetBool("Walk", true);
        }
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
