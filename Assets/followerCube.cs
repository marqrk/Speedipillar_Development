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
    public GameObject nextCube;
    public float size = 0.5f;
    float initDistance;
    Vector3 velocity = Vector3.zero;


    private void Start()
    {
        Vector3 sizeVec = Vector3.zero;
        sizeVec.x = size;
        sizeVec.y = size;
        sizeVec.z = size;
        transform.localScale = sizeVec;



        initDistance = Vector3.Distance(transform.position, nextCube.transform.position);

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
                else //(Vector3.Distance(transform.position, nextCube.transform.position) > initDistance)
                {
                    //Vector3 followMove = Vector3.MoveTowards(transform.position, frontCube.transform.position, 0.1f);
                    // followMove.y = transform.position.y;
                    //transform.position = followMove;

                    Vector3 target = Vector3.zero;

                    transform.LookAt(nextCube.transform.position);
                    if (nextCube.name == "Speedipillar_Head")
                    {
                        target = nextCube.transform.TransformPoint(new Vector3(0, 0.5f, -1.75f));
                    }
                    else
                    {
                        target = nextCube.transform.TransformPoint(new Vector3(0, 0, -1.5f));
                    }

                    if (Input.touchCount == 0)
                    {
                        if (cubeRigibody.velocity.magnitude < baseSpeed)
                        {
                            //cubeRigibody.MovePosition(transform.position + transform.forward * baseSpeed * Time.deltaTime);
                            cubeRigibody.position = Vector3.SmoothDamp(cubeRigibody.position, target, ref velocity, Time.deltaTime, baseSpeed);
                        }
                    }
                    else
                    {
                        if (cubeRigibody.velocity.magnitude < Speed)
                        {
                            //cubeRigibody.MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);
                            cubeRigibody.position = Vector3.SmoothDamp(cubeRigibody.position, target, ref velocity, Time.deltaTime, Speed);
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
