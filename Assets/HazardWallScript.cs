using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardWallScript : MonoBehaviour
{
    public GameObject player;
    public GameObject deathButton;
    public GameObject failure;
    public GameObject returnLvl;
    // Start is called before the first frame update

    public BasicPlayerMovement move = null;
    void Start()
    {
        move = player.GetComponent<BasicPlayerMovement>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collide)
    {
        if(collide.gameObject.name == player.name)
        {
            deathButton.SetActive(true);
            failure.SetActive(true);
            returnLvl.SetActive(true);
            move.animator.SetInteger("AliveState", 2);

            move.AliveState = 2;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name)
        {
            deathButton.SetActive(true);
            failure.SetActive(true);
            returnLvl.SetActive(true);
            move.AliveState = 2;
        }
    }
}
