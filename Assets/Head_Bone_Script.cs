using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Bone_Script : MonoBehaviour
{
    public Rigidbody cubeRigibody;
    public Rigidbody boneRigidbody;
    public GameObject playerobj;

    // Start is called before the first frame update
    void Start()
    {

        boneRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 facedirection = cubeRigibody.rotation.eulerAngles;
        facedirection.y += 180;


        Vector3 offset = new Vector3(0, 0.3f, 0);

        Vector3 position = cubeRigibody.position - offset;

        

        boneRigidbody.position = position;

        if (playerobj.GetComponent<BasicPlayerMovement>().AliveState == 0)
        {
            boneRigidbody.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(playerobj.GetComponent<BasicPlayerMovement>().AliveState == 1)
        {
            boneRigidbody.rotation = Quaternion.Euler(facedirection);
        }
    }
}
