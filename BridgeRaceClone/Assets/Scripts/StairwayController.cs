using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairwayController : MonoBehaviour
{
    MovementController movementController;
    StackController stackController;
    public GameObject cubePrefab;

    private void Start()
    {
        stackController = GetComponent<StackController>();
        movementController = GetComponent<MovementController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Stairway"))
        {
            if (GameObject.Find("StackObject").transform.childCount > 0)
            {

                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                other.gameObject.tag = "BlueStep";
                Instantiate(cubePrefab, StackList.instance.blueStacks[StackList.instance.blueStacks.Count - 1].gameObject.GetComponent<CubeSpawner>().spawnPoint, Quaternion.identity);
                stackController.stackPose -= new Vector3(0, 0.5f, 0);

                Destroy(StackList.instance.blueStacks[StackList.instance.blueStacks.Count - 1].gameObject);
                StackList.instance.blueStacks.RemoveAt(StackList.instance.blueStacks.Count - 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("GreenStep") || other.gameObject.CompareTag("RedStep"))
        {
            if (GameObject.Find("StackObject").transform.childCount > 0)
            {
               
                other.gameObject.transform.tag = "BlueStep";
                other.gameObject.GetComponent<MeshRenderer>().material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                Instantiate(cubePrefab, StackList.instance.blueStacks[StackList.instance.blueStacks.Count - 1].gameObject.GetComponent<CubeSpawner>().spawnPoint, Quaternion.identity);
                stackController.stackPose -= new Vector3(0, 0.5f, 0);
                Destroy(StackList.instance.blueStacks[StackList.instance.blueStacks.Count - 1].gameObject);
                StackList.instance.blueStacks.RemoveAt(StackList.instance.blueStacks.Count - 1);
            }

            if (GameObject.Find("StackObject").transform.childCount == 0)
            {
                movementController.speed = 0f;
            }
        }

        if (other.gameObject.CompareTag("StackControl"))
        {
            if (StackList.instance.blueStacks.Count <= 0)
            {
                stackController.stackPose = Vector3.zero;
            }
            else
            {
                stackController.stackPose = StackList.instance.blueStacks[StackList.instance.blueStacks.Count - 1].transform.localPosition + new Vector3(0, 0.5f, 0);
            }
        }
    }

    
}
