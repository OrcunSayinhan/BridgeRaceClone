using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedBotController : MonoBehaviour
{
    public bool closest, furthest;
    public Vector3 destination;
    public NavMeshAgent navMeshAgent;
    public LayerMask layers;
    public Transform[] finalDestinations;
    public Animator anim;
    public int randomNumber;
    public bool isMove;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        closest = true;
        randomNumber = Random.Range(0,3);
        isMove = true;

    }

    private void Update()
    {
        if (isMove)
        {
            CubeFinder();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LastDestination"))
        {
            randomNumber = 3;
            navMeshAgent.SetDestination(finalDestinations[randomNumber].transform.position);
        }
    }


    public void CubeFinder()
    {
        Collider[] objectsInArea = Physics.OverlapSphere(transform.position, 10f, layers);

        if (objectsInArea.Length > 0)
        {
            anim.SetBool("canRun", true);

            if (closest)
            {
                destination = objectsInArea[objectsInArea.Length - 1].transform.position;
                navMeshAgent.SetDestination(destination);
                if (StackList.instance.redStacks.Count > 0)
                {
                    GameObject.Find("RedStackObject").transform.GetChild
                        (GameObject.Find("RedStackObject").transform.childCount - 1).gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                if (StackList.instance.redStacks.Count > 8)
                {
                    navMeshAgent.SetDestination(finalDestinations[randomNumber].transform.position);
                }
            }

            if (furthest)
            {
                destination = objectsInArea[0].transform.position;
                navMeshAgent.SetDestination(destination);
                if (StackList.instance.redStacks.Count > 0)
                {
                    GameObject.Find("RedStackObject").transform.GetChild
                        (GameObject.Find("RedStackObject").transform.childCount - 1).gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                if (StackList.instance.redStacks.Count > 6)
                {
                    navMeshAgent.SetDestination(finalDestinations[randomNumber].transform.position);

                }
            }
        }

        else if (objectsInArea.Length == 0 && StackList.instance.redStacks.Count == 0)
        {
            navMeshAgent.SetDestination(new Vector3(-1.23f, 0.16f, -5.33f));

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 10f);
    }
}
