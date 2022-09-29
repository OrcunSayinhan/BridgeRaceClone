using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject leftUpDoor;
    public GameObject rightUpDoor;
    public GameObject leftDownDoor;
    public GameObject rightDownDoor;
    public GameObject leftLimit;
    public GameObject rightLimit;
    GameObject blueCubes;
    GameObject greenCubes;
    GameObject redCubes;


    private void Start()
    {
        blueCubes = GameObject.Find("BlueCubesSecondPlane");
        greenCubes = GameObject.Find("GreenCubesSecondPlane");
        redCubes = GameObject.Find("RedCubesSecondPlane");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueCharacter"))
        {
            leftUpDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            leftDownDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            rightUpDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            rightDownDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            leftLimit.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            rightLimit.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;

            for (int i = 0; i < blueCubes.gameObject.transform.childCount; i++)
            {
                blueCubes.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }




           // transform.Translate(Vector3.Lerp(transform.position, Vector3.forward * 2, 5f));
        }

        if (other.gameObject.CompareTag("GreenCharacter"))
        {
            leftUpDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            leftDownDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            rightUpDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            rightDownDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            leftLimit.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            rightLimit.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;

            for (int i = 0; i < greenCubes.gameObject.transform.childCount; i++)
            {
                greenCubes.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }

            //transform.Translate(Vector3.Lerp(transform.position, Vector3.forward * 1.5f, 5f));

            //this.transform.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }


        if (other.gameObject.CompareTag("RedCharacter"))
        {

            leftUpDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            leftDownDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            rightUpDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            rightDownDoor.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            leftLimit.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
            rightLimit.GetComponent<MeshRenderer>().material = other.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;

            for (int i = 0; i < redCubes.gameObject.transform.childCount; i++)
            {
                redCubes.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }



            //transform.Translate(Vector3.Lerp(transform.position, Vector3.forward * 1.5f, 5f));


            // this.transform.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BlueCharacter"))
        {
            this.transform.gameObject.GetComponent<BoxCollider>().isTrigger = false;

        }
    }



}
