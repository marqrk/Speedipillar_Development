using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerCube : MonoBehaviour
{
    public int AliveState;
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

        AliveState = 0;
    }

    // Update is called once per frame
    void Update()
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
                    GetComponent<Rigidbody>().velocity = randDirection;
                    AliveState = 2;
                    break;
                }
                if(Vector3.Distance(transform.position, frontCube.transform.position) > initDistance)
                {
                    Vector3 followMove = Vector3.MoveTowards(transform.position, frontCube.transform.position, 0.1f);
                    followMove.y = transform.position.y;
                    transform.position = followMove;
                    transform.LookAt(frontCube.transform.position);
                }
                break;
            case 2:
            case 3:
                break;
        }
    }
}
