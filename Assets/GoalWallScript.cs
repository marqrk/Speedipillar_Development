using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalWallScript : MonoBehaviour
{
    public GameObject jsonHandlerObj;
    private JsonHandlerScript json;
    public GameObject player;
    public GameObject goalButton;
    public GameObject nextLevelButton;
    public GameObject victory;
    public GameObject LvlSelectButton;
    // Start is called before the first frame update
    BasicPlayerMovement move = null;

    public int CurrentLevel;

    void Start()
    {
        move = player.GetComponent<BasicPlayerMovement>();

        json = jsonHandlerObj.GetComponent<JsonHandlerScript>();
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
            move.animator.SetInteger("AliveState", 3);


            json.UpdatePlayerSave(CurrentLevel);
        }
    }
}
