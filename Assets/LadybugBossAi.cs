using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadybugBossAi : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public GameObject LadybugHead;

    public GameObject jsonHandlerObj;
    private JsonHandlerScript json;

    public float speed = 15f;

    public GameObject goalButton;
    public GameObject nextLevelButton;
    public GameObject victory;
    public GameObject LvlSelectButton;

    public int Health = 4;

    public int CurrentLevel;

    Vector3 StartingPos;

    bool charging = false;
    bool finishedCharge = false;

    void Start()
    {
        StartingPos = transform.position;

        json = jsonHandlerObj.GetComponent<JsonHandlerScript>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Health <= 0)
        {
            goalButton.SetActive(true);
            victory.SetActive(true);
            nextLevelButton.SetActive(true);
            LvlSelectButton.SetActive(true);
            player.GetComponent<BasicPlayerMovement>().AliveState = 3;

            json.UpdatePlayerSave(CurrentLevel);
        }
        if (player.GetComponent<BasicPlayerMovement>().AliveState == 1 || player.GetComponent<BasicPlayerMovement>().AliveState == 4)
        {
            if (!charging)
            {
                Vector3 LookingPos = new Vector3(player.transform.position.x, 0.79f, player.transform.position.z);
                transform.LookAt(LookingPos);

                Invoke("BlinkersRed", 3.0f);
                Invoke("BlinkersBlack", 3.5f);
                Invoke("BlinkersRed", 4.0f);
                Invoke("BlinkersBlack", 4.5f);
                Invoke("startCharge", 5);
            }
            else
            {
                Vector3 targetPosition = StartingPos + transform.forward * 20;
                if (!finishedCharge)
                {
                    chargeAttack(targetPosition);
                    Invoke("endFwdCharge", 3);
                }
                else
                {
                    chargeRecovery();
                }
            }
        }
    }

    void BlinkersRed()
    {
        //LadybugHead.GetComponent<BlinkingScript>().AttackBlinkers();
        var renderer = LadybugHead.GetComponent<Renderer>();

        renderer.material.SetColor("_Color", Color.red);
    }

    void BlinkersBlack()
    {
        var renderer = LadybugHead.GetComponent<Renderer>();

        renderer.material.SetColor("_Color", Color.black);
    }

    void startCharge()
    {
        charging = true;
    }

    void chargeAttack(Vector3 targPos)
    {
        if(Vector3.Distance(transform.position, targPos) < 0.001f)
        {
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targPos, speed * Time.deltaTime);
        }
    }

    void endFwdCharge()
    {
        finishedCharge = true;
    }

    void chargeRecovery()
    {
        if (Vector3.Distance(transform.position, StartingPos) < 0.001f)
        {
            charging = false;
            finishedCharge = false;
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, StartingPos, speed * Time.deltaTime);
        }
    }
}
