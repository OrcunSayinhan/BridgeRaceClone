using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Vector3 spawnPoint;

    

    private void Start()
    {
        spawnPoint = transform.position;
    }
}
