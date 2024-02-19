using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadybugBossWPScript : MonoBehaviour
{

    public GameObject player;
    public GameObject Ladybug;
    public bool Triggered = false;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == player.name && !Triggered && player.GetComponent<BasicPlayerMovement>().AliveState != 2)
        {
            var SpotRender = this.GetComponent<Renderer>();

            SpotRender.material.SetColor("_Color", Color.red);

            LadybugBossAi script = Ladybug.GetComponent<LadybugBossAi>();
            script.Health -= 1;

            Triggered = true;
            
            if (this.name == "BackRightWeakPt" || this.name == "FrontRightWeakPt") {
                player.transform.rotation = Quaternion.LookRotation( Ladybug.transform.right);
             }
            else
            {
                player.transform.rotation = Quaternion.LookRotation(Ladybug.transform.right * -1);
            }
            player.GetComponent<BasicPlayerMovement>().AliveState = 4;

            Invoke("releaseLock", 1);
        }
    }

    void releaseLock()
    {
        player.GetComponent<BasicPlayerMovement>().AliveState = 1;
    }
}
