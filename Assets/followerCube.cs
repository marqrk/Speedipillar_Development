using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerCube : MonoBehaviour
{
    public float Acceleration;
    public float Speed = 15;
    public float baseAccel;
    public float baseSpeed = 7;
    public int AliveState;

    Rigidbody cubeRigibody;


    public GameObject frontCube;
    public float size = 0.5f;
    float initDistance;



    private void Start()
    {
        Vector3 sizeVec = Vector3.zero;
        sizeVec.x = size;
        sizeVec.y = size;
        sizeVec.z = size;
        transform.localScale = sizeVec;

        initDistance = Vector3.Distance(transform.position, frontCube.transform.position);

        cubeRigibody = GetComponent<Rigidbody>();
        cubeRigibody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationZ;

        AliveState = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (AliveState)
        {
            case 0:
                if (Input.touchCount > 0) { AliveState = 1; }
                break;
            case 1:
                if(frontCube.GetComponent<BasicPlayerMovement>().AliveState == 2)
                {
                    Vector3 randDirection = new Vector3(Random.Range(-5, 5), Random.Range(0, 5), Random.Range(-5, 5));
                    //transform.position = Vector3.MoveTowards(transform.position, randDirection, 5f);
                    cubeRigibody.velocity = randDirection * 2;
                    AliveState = 2;
                    break;
                }
                if(Vector3.Distance(transform.position, frontCube.transform.position) > initDistance)
                {
                    //Vector3 followMove = Vector3.MoveTowards(transform.position, frontCube.transform.position, 0.1f);
                   // followMove.y = transform.position.y;
                    //transform.position = followMove;
                    transform.LookAt(frontCube.transform.position);

                    if (Input.touchCount == 0)
                    {
                        if (cubeRigibody.velocity.magnitude < baseSpeed)
                        {
                            cubeRigibody.MovePosition(transform.position + transform.forward * baseSpeed * Time.deltaTime);
                        }
                    }
                    else
                    {
                        if (cubeRigibody.velocity.magnitude < Speed)
                        {
                            cubeRigibody.MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);
                        }
                    }
                }
                break;
            case 2:
            case 3:
                break;
        }
    }
}
