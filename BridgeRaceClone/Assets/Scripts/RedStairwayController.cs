using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedStairwayController : MonoBehaviour
{

    RedStackController stackController;
    NavMeshAgent navMeshAgent;
    public GameObject cubePrefab;

    private void Start()
    {
        stackController = GetComponent<RedStackController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Stairway") || other.gameObject.CompareTag("BlueStep"))
        {
            if (GameObject.Find("RedStackObject").transform.childCount > 0)
            {
                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                other.gameObject.tag = "RedStep";
                Instantiate(cubePrefab, StackList.instance.redStacks[StackList.instance.redStacks.Count - 1].gameObject.GetComponent<CubeSpawner>().spawnPoint, Quaternion.identity);
                stackController.stackPose -= new Vector3(0, 0.5f, 0);

                Destroy(StackList.instance.redStacks[StackList.instance.redStacks.Count - 1].gameObject);
                StackList.instance.redStacks.RemoveAt(StackList.instance.redStacks.Count - 1);

            }
        }

        // LastStep diðer karakterlerde hata verebilir
        //if (other.gameObject.CompareTag("LastStep") || other.gameObject.CompareTag("BlueTag") || other.gameObject.CompareTag("GreenTag"))
        //{
        //    other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        //    leftUpDoor.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
        //    leftDownDoor.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
        //    rightUpDoor.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
        //    rightDownDoor.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
        //    GameObject.Find("SideLimits").transform.GetChild(0).GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
        //    GameObject.Find("SideLimits").transform.GetChild(1).GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;

        //    transform.Translate(Vector3.Lerp(transform.position, Vector3.forward * 1.5f, 5f));
        //    other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        //    other.gameObject.transform.tag = "RedTag";
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueStep") || other.gameObject.CompareTag("GreenStep"))
        {
            if (GameObject.Find("RedStackObject").transform.childCount > 0)
            {

                other.gameObject.transform.tag = "RedStep";
                other.gameObject.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                Instantiate(cubePrefab, StackList.instance.redStacks[StackList.instance.redStacks.Count - 1].gameObject.GetComponent<CubeSpawner>().spawnPoint, Quaternion.identity);
                stackController.stackPose -= new Vector3(0, 0.5f, 0);

                Destroy(StackList.instance.redStacks[StackList.instance.redStacks.Count - 1].gameObject);
                StackList.instance.redStacks.RemoveAt(StackList.instance.redStacks.Count - 1);
            }
        }

        if (other.gameObject.CompareTag("StackControl"))
        {
            if (StackList.instance.redStacks.Count <= 0)
            {
                stackController.stackPose = Vector3.zero;
            }
            else
            {
                stackController.stackPose = StackList.instance.redStacks[StackList.instance.redStacks.Count - 1].transform.localPosition + new Vector3(0, 0.5f, 0);
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
