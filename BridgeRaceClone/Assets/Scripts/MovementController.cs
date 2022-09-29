using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementController : MonoBehaviour
{
    public float vertical;
    public DynamicJoystick dynamicJoystick;
    public float speed;
    public float turnSpeed;
    public Animator anim;
    public Rigidbody rb;
    public Vector3 addedPos;
    public bool isMove;
    public bool isFinish;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isMove = true;
        
    }
    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {

            JoystickMovement();

        }
        else
        {
            anim.SetBool("canRun", false);
        }

        if (vertical < 0)
        {
            speed = 5f;
        }
        if (isFinish)
        {
            if (StackList.instance.greenStacks.Count  > 0)
            {
                for (int i = 0; i < StackList.instance.greenStacks.Count; i++)
                {
                    Destroy(StackList.instance.greenStacks[i].gameObject);
                    StackList.instance.greenStacks.RemoveAt(i);

                }
            }
            if (StackList.instance.redStacks.Count > 0)
            {
                for (int i = 0; i < StackList.instance.redStacks.Count; i++)
                {
                    Destroy(StackList.instance.redStacks[i].gameObject);
                    StackList.instance.redStacks.RemoveAt(i);

                }
            }

            if (StackList.instance.blueStacks.Count > 0)
            {
                for (int i = 0; i < StackList.instance.blueStacks.Count; i++)
                {
                    Destroy(StackList.instance.blueStacks[i].gameObject);
                    StackList.instance.blueStacks.RemoveAt(i);

                }
            }
        }

        
    }

    private void JoystickMovement()
    {
        if (!isFinish)
        {
            if (isMove == true)
            {
                float horizontal = dynamicJoystick.Horizontal;
                vertical = dynamicJoystick.Vertical;
                addedPos = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
                if (horizontal != 0 || vertical != 0)
                {
                    anim.SetBool("canRun", true);
                }
                transform.position += addedPos;

                Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);

            }


        }


        
        
        
    }
}
