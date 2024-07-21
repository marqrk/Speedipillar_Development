using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStickScript : MonoBehaviour
{
    public GameObject player;
    private BasicPlayerMovement playerControl;

    Vector3 initialPos;

    Vector3 touchStartPos;

    RectTransform stickPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = new Vector3(-290f, -95f, 0f);
        stickPos = GetComponent<RectTransform>();
        playerControl = player.GetComponent<BasicPlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerControl.AliveState == 1 && playerControl.usingStick)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPos = Camera.main.ScreenToViewportPoint(touch.position);

                if(touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touchPos;

                    touchStartPos.x -= 0.5f;
                    touchStartPos.x *= 800f;

                    touchStartPos.y -= 0.5f;
                    touchStartPos.y *= 400f;
                }
                else if(touch.phase == TouchPhase.Moved)
                {
                    
                }
                else if(touch.phase == TouchPhase.Ended)
                {
                    touchStartPos = Vector3.zero;
                }


                if(touchStartPos.x < -220f && touchStartPos.x > -360f && touchStartPos.y < -20f && touchStartPos.y > -170f)
                {

                    touchPos.x -= 0.5f;
                    touchPos.x *= 800f;

                    touchPos.y -= 0.5f;
                    touchPos.y *= 400f;

                    //X axis limits:  -340f, -240f
                    //Y axis limits:  -145f, -45f

                    Vector3 finalPos = touchPos - initialPos;

                    finalPos = Vector3.ClampMagnitude(finalPos, 50.0f);

                    Quaternion faceAngle = Quaternion.LookRotation(new Vector3(finalPos.x, 0, finalPos.y));
                    playerControl.cubeRigibody.transform.rotation = faceAngle;
                    if (playerControl.cubeRigibody.velocity.magnitude < playerControl.speed)
                    {
                        playerControl.cubeRigibody.AddForce(playerControl.transform.forward * playerControl.acceleration);
                    }

                    //Debug.Log("TouchPos: " + touchPos);

                    finalPos.x -= 290f;
                    finalPos.y -= 95f;

                    //Debug.Log("FinalPos: " + finalPos);


                    stickPos.anchoredPosition = finalPos;
                }
                else
                {
                    
                    if (playerControl.cubeRigibody.velocity.magnitude < playerControl.baseSpeed)
                    {
                        playerControl.cubeRigibody.AddForce(playerControl.transform.forward * playerControl.baseAccel);
                    }

                    stickPos.anchoredPosition = initialPos;
                }
            }
            else
            {
                if (playerControl.cubeRigibody.velocity.magnitude < playerControl.baseSpeed)
                {
                    playerControl.cubeRigibody.AddForce(playerControl.transform.forward * playerControl.baseAccel);
                }

                stickPos.anchoredPosition = initialPos;
            }
        }
    }
}
