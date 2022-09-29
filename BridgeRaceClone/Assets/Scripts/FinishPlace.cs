using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class FinishPlace : MonoBehaviour
{
    public Transform firstPlace;
    public Transform secondPlace;
    public Transform thirdPlace;
    GameObject greenBot;
    GameObject redBot;
    GameObject myCharacter;
    GameObject camFollow;
    GameObject finishBridge;
    GameObject finishEvent;

    private void Start()
    {
        greenBot = GameObject.Find("GreenBot");
        redBot = GameObject.Find("RedBot");
        myCharacter = GameObject.Find("MyCharacter");
        camFollow = GameObject.Find("Main Camera");
        finishBridge = GameObject.Find("FinishBridge");
        finishEvent = GameObject.Find("FinishEvent");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueCharacter"))
        {
            
           


            finishBridge.gameObject.SetActive(false);
            other.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.GetComponent<MovementController>().anim.SetBool("canRun", false);
            other.gameObject.transform.GetComponent<MovementController>().anim.Play("VictoryDance");
            other.gameObject.transform.GetComponent<MovementController>().isMove = false;
            other.gameObject.transform.DOMove(firstPlace.position, 0.08f);
            other.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0);
            camFollow.GetComponent<CamFollow>().isFinish = true;
            finishEvent.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            finishEvent.transform.GetChild(1).gameObject.SetActive(true);

            other.gameObject.transform.GetComponent<MovementController>().isFinish = true;







            //greenBot.gameObject.transform.GetComponent<Rigidbody>().useGravity = false;
            greenBot.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            greenBot.transform.GetComponent<NavMeshAgent>().enabled = false;
            greenBot.transform.DOMove(secondPlace.position, 0.08f);
            greenBot.transform.DORotate(new Vector3(0, 180, 0), 0);
            greenBot.GetComponent<BotController>().isMove = false;
            greenBot.GetComponent<BotController>().anim.SetBool("canRun", false);
            greenBot.GetComponent<BotController>().anim.Play("Cry");


            //redBot.gameObject.transform.GetComponent<Rigidbody>().useGravity = false;
            redBot.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            redBot.gameObject.transform.DOMove(thirdPlace.position, 0.08f);
            redBot.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0);
            redBot.transform.GetComponent<RedBotController>().anim.SetBool("canRun", false);
            redBot.transform.GetComponent<RedBotController>().anim.Play("Cry");
            redBot.transform.GetComponent<RedBotController>().isMove = false;
            redBot.transform.GetComponent<NavMeshAgent>().enabled = false;
        }

        if (other.gameObject.CompareTag("GreenCharacter"))
        {
            finishBridge.gameObject.SetActive(false);
            other.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<BotController>().anim.SetBool("canRun", false);
            other.GetComponent<BotController>().anim.Play("VictoryDance");
            other.transform.DOMove(firstPlace.position, 0.08f);
            other.transform.DORotate(new Vector3(0, 180, 0), 0);
            other.GetComponent<BotController>().isMove = false;
            camFollow.GetComponent<CamFollow>().isFinish = true;
            finishEvent.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            finishEvent.transform.GetChild(1).gameObject.SetActive(true);

            myCharacter.gameObject.transform.GetComponent<MovementController>().isFinish = true;



            myCharacter.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            myCharacter.gameObject.transform.GetComponent<MovementController>().anim.SetBool("canRun", false);
            myCharacter.gameObject.transform.GetComponent<MovementController>().anim.Play("Cry");
            myCharacter.gameObject.transform.GetComponent<MovementController>().isMove = false;
            myCharacter.gameObject.transform.DOMove(secondPlace.position, 0.08f);
            myCharacter.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0);

            redBot.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            redBot.gameObject.transform.DOMove(thirdPlace.position, 0.08f);
            redBot.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0);
            redBot.transform.GetComponent<RedBotController>().anim.SetBool("canRun", false);
            redBot.transform.GetComponent<RedBotController>().anim.Play("Cry");
            redBot.transform.GetComponent<RedBotController>().isMove = false;
            redBot.transform.GetComponent<NavMeshAgent>().enabled = false;
        }

        if (other.gameObject.CompareTag("RedCharacter"))
        {
            finishBridge.gameObject.SetActive(false);
            other.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.DOMove(firstPlace.position, 0.08f);
            other.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0);
            other.transform.GetComponent<RedBotController>().anim.SetBool("canRun", false);
            other.GetComponent<RedBotController>().anim.SetBool("canRun", false);
            other.GetComponent<RedBotController>().anim.Play("VictoryDance");
            other.transform.GetComponent<RedBotController>().isMove = false;
            other.transform.GetComponent<NavMeshAgent>().enabled = false;
            camFollow.GetComponent<CamFollow>().isFinish = true;
            finishEvent.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            finishEvent.transform.GetChild(1).gameObject.SetActive(true);

            myCharacter.gameObject.transform.GetComponent<MovementController>().isFinish = true;



            greenBot.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            greenBot.transform.GetComponent<NavMeshAgent>().enabled = false;
            greenBot.transform.DOMove(thirdPlace.position, 0.08f);
            greenBot.transform.DORotate(new Vector3(0, 180, 0), 0);
            greenBot.GetComponent<BotController>().isMove = false;
            greenBot.GetComponent<BotController>().anim.SetBool("canRun", false);
            greenBot.GetComponent<BotController>().anim.Play("Cry");

            myCharacter.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            myCharacter.gameObject.transform.GetComponent<MovementController>().anim.SetBool("canRun", false);
            myCharacter.gameObject.transform.GetComponent<MovementController>().anim.Play("Cry");
            myCharacter.gameObject.transform.GetComponent<MovementController>().isMove = false;
            myCharacter.gameObject.transform.DOMove(secondPlace.position, 0.08f);
            myCharacter.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0);


        }



    }





}
