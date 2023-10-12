using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateScript : MonoBehaviour
{
    public GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerObj.transform.position);
        Vector3 followPos = playerObj.transform.position;

        followPos.z = playerObj.transform.position.z - 5;
        followPos.y = playerObj.transform.position.y + 2f;

        transform.position = followPos;

    }
}
