using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardWallScript : MonoBehaviour
{
    public GameObject player;
    public GameObject deathButton;
    public GameObject failure;
    // Start is called before the first frame update

    BasicPlayerMovement move = null;
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
            move.AliveState = 2;
        }
    }
}
