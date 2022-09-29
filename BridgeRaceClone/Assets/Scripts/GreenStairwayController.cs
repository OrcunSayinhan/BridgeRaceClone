using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenStairwayController : MonoBehaviour
{
    GreenStackController stackController;
    //public GameObject leftUpDoor;
    //public GameObject rightUpDoor;
    //public GameObject leftDownDoor;
    //public GameObject rightDownDoor;
    public GameObject cubePrefab;
    NavMeshAgent navMeshAgent;

    private void Start()
    {
        stackController = GetComponent<GreenStackController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Stairway") || other.gameObject.CompareTag("BlueStep"))
        {
            if (GameObject.Find("GreenStackObject").transform.childCount > 0)
            {
                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                other.gameObject.tag = "GreenStep";
                Instantiate(cubePrefab, StackList.instance.greenStacks[StackList.instance.greenStacks.Count - 1].gameObject.GetComponent<CubeSpawner>().spawnPoint, Quaternion.identity);
                stackController.stackPose -= new Vector3(0, 0.5f, 0);

                Destroy(StackList.instance.greenStacks[StackList.instance.greenStacks.Count - 1].gameObject);
                StackList.instance.greenStacks.RemoveAt(StackList.instance.greenStacks.Count - 1);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueStep")|| other.gameObject.CompareTag("RedStep"))
        {
            if (GameObject.Find("GreenStackObject").transform.childCount > 0)
            {

                other.gameObject.transform.tag = "GreenStep";
                other.gameObject.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                Instantiate(cubePrefab, StackList.instance.greenStacks[StackList.instance.greenStacks.Count - 1].gameObject.GetComponent<CubeSpawner>().spawnPoint, Quaternion.identity);
                stackController.stackPose -= new Vector3(0, 0.5f, 0);

                Destroy(StackList.instance.greenStacks[StackList.instance.greenStacks.Count - 1].gameObject);
                StackList.instance.greenStacks.RemoveAt(StackList.instance.greenStacks.Count - 1);
            }
        }

        if (other.gameObject.CompareTag("StackControl"))
        {
            if (StackList.instance.greenStacks.Count <= 0)
            {
                stackController.stackPose = Vector3.zero;
            }
            else
            {
                stackController.stackPose = StackList.instance.greenStacks[StackList.instance.greenStacks.Count - 1].transform.localPosition + new Vector3(0, 0.5f, 0);
            }

        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Way"))
        {
            navMeshAgent.speed = 12.5f;
        }
        else
        {
            navMeshAgent.speed = 6f;
        }
    }
}


   

