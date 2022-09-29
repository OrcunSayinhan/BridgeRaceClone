using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackList : MonoBehaviour
{
    public static StackList instance;

    public List<GameObject> blueStacks  = new List<GameObject>();
    public List<GameObject> greenStacks = new List<GameObject>();
    public List<GameObject> redStacks   = new List<GameObject>();



    private void Awake()
    {
        instance = this;
    }

}
