using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateScript : MonoBehaviour
{
    public GameObject playerObj;
    public bool overheadCam;
    public bool BehindCam;
    public bool OHBoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (overheadCam)
        {
            if (OHBoss)
            {
                if (playerObj.GetComponent<BasicPlayerMovement>().AliveState == 2)
                {
                    transform.LookAt(playerObj.transform.position);
                }
                else
                {
                    transform.LookAt(playerObj.transform.position);
                    Vector3 followPos = playerObj.transform.position;

                    followPos.z = playerObj.transform.position.z - 3;
                    followPos.y = playerObj.transform.position.y + 16f;

                    Vector3 SmoothFollowPos = Vector3.Lerp(transform.position, followPos, 15f * Time.deltaTime);

                    transform.position = followPos;
                }
            }
            else
            {
                if (playerObj.GetComponent<BasicPlayerMovement>().AliveState == 2)
                {
                    transform.LookAt(playerObj.transform.position);
                }
                else
                {
                    transform.LookAt(playerObj.transform.position);
                    Vector3 followPos = playerObj.transform.position;

                    followPos.z = playerObj.transform.position.z - 1;
                    followPos.y = playerObj.transform.position.y + 8f;

                    Vector3 SmoothFollowPos = Vector3.Lerp(transform.position, followPos, 15f * Time.deltaTime);

                    transform.position = followPos;
                }
            }
        }
        else if (BehindCam)
        {
            if (playerObj.GetComponent<BasicPlayerMovement>().AliveState == 2)
            {
                transform.LookAt(playerObj.transform.position);
            }
            else
            {
                transform.LookAt(playerObj.transform.position);
                Vector3 followPos = playerObj.transform.position;

                followPos.z = playerObj.transform.position.z - 8f;
                followPos.y = playerObj.transform.position.y + 1f;

                transform.position = followPos;

                Vector3 SmoothFollowPos = Vector3.Lerp(transform.position, followPos, 15f * Time.deltaTime);
                transform.position = SmoothFollowPos;
            }
        }
        else
        {
            if (playerObj.GetComponent<BasicPlayerMovement>().AliveState == 2)
            {
                transform.LookAt(playerObj.transform.position);
            }
            else
            {
                transform.LookAt(playerObj.transform.position);
                Vector3 followPos = playerObj.transform.position;

                followPos.z = playerObj.transform.position.z - 6f;
                followPos.y = playerObj.transform.position.y + 3f;

                transform.position = followPos;

                Vector3 SmoothFollowPos = Vector3.Lerp(transform.position, followPos, 15f * Time.deltaTime);
                transform.position = SmoothFollowPos;
            }
        }
    }
}
