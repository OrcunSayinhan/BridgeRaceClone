using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GreenStackController : MonoBehaviour
{
    public Transform stackObject;
    public Vector3 stackPose;
    Vector3 zeroRotate;


    private void Start()
    {
        stackPose = Vector3.zero;
        zeroRotate = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Green"))
        {
            StackList.instance.greenStacks.Add(other.gameObject);
            other.gameObject.transform.parent = stackObject.transform;
            other.gameObject.transform.DOLocalRotate(zeroRotate, 0f);
            other.gameObject.transform.DOLocalMove(stackPose, 0.2f);
            stackPose += new Vector3(0, 0.5f, 0);
        }
    }
}
