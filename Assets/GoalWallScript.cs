using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalWallScript : MonoBehaviour
{
    public GameObject player;
    public GameObject goalButton;
    public GameObject nextLevelButton;
    public GameObject victory;
    public GameObject LvlSelectButton;
    // Start is called before the first frame update
    BasicPlayerMovement move = null;

    void Start()
    {
        move = player.GetComponent<BasicPlayerMovement>();

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.name == player.name)
        {
            goalButton.SetActive(true);
            victory.SetActive(true);
            nextLevelButton.SetActive(true);
            LvlSelectButton.SetActive(true);
            move.AliveState = 3;
        }
    }
}
