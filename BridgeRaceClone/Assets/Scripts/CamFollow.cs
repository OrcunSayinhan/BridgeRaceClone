using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public bool isFinish;
    public Transform lastCamDestination;
    public Vector3 newCamDest;

    private void LateUpdate()
    {
        if (isFinish == true)
        {
            transform.position = Vector3.Lerp(transform.position, lastCamDestination.position, 2 * Time.deltaTime);
            transform.rotation = Quaternion.Euler(37.3733253f, 359.025177f, 359.991028f);

        }
        else
        {
            transform.position = player.position + offset;

        }

        // Quaternion(0.320381463,-0.00803334452,0.00265129423,0.947250903)

        // Vector3(37.3733253,359.025177,359.991028)




    }
}
