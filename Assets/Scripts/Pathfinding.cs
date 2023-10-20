using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : StateMachine
{
    public Transform[] points;

    private NavMeshAgent nav;
    private int destPoint;
    public Animator anim;
    public GameObject player;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
   
    void FixedUpdate()
    {
        nav.destination = player.transform.position;
    }

    void Update()
    {
       if (!nav.pathPending)
        {
            anim.SetBool("Walk", true);
        }
    }
}
