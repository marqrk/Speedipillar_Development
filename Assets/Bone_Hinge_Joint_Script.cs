using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone_Hinge_Joint_Script : MonoBehaviour
{

    public HingeJoint joint;
    public JointMotor motor;
    public GameObject Head;

    BasicPlayerMovement playermove;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        //JointSpring spring = joint.spring;
        //spring.spring = 10;
        //spring.damper = 2;
        //spring.targetPosition = 0;

        //joint.spring = spring;

        playermove = Head.GetComponent<BasicPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if(playermove.AliveState == 2)
        {
            Destroy(GetComponent<HingeJoint>());
            BoxCollider box = gameObject.AddComponent<BoxCollider>();
        }

        //if (joint.angle > 10)
        //{
        //    JointMotor newMotor = joint.motor;
        //    newMotor.targetVelocity = -50;
        //    newMotor.force = 100;
        //    joint.motor = newMotor;
        //}
        //else if (joint.angle < 10 && joint.angle > 0)
        //{
        //    JointMotor newMotor = joint.motor;
        //    newMotor.targetVelocity = -20;
        //    newMotor.force = 50;
        //    joint.motor = newMotor;
        //}
        //else if (joint.angle < -10)
        //{
        //    JointMotor newMotor = joint.motor;
        //    newMotor.targetVelocity = 50;
        //    newMotor.force = 100;
        //    joint.motor = newMotor;
        //}
        //else if (joint.angle > -10 && joint.angle < 0)
        //{
        //    JointMotor newMotor = joint.motor;
        //    newMotor.targetVelocity = 20;
        //    newMotor.force = 50;
        //    joint.motor = newMotor;
        //}
        //else
        //{
        //    JointMotor newMotor = joint.motor;
        //    newMotor.targetVelocity = 0;
        //    newMotor.force = 0;
        //    joint.motor = newMotor;
        //}
    }
}
