 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird_Script : MonoBehaviour
{

    public GameObject speedipillar;
    public int AttackState = 0;
    public Vector3 seekTarget;
    public float attackDuration;
    public float advanceDistance;
    public float attackSpeed;
    public float attackAccel;
    BasicPlayerMovement movementScript;
    public Rigidbody rb;

    public void SetAttackState(int val)
    {
        AttackState = val;
    }

    void beginAttack()
    {
        AttackState = 3;
        Invoke("endAttack", attackDuration);
    }

    void endAttack()
    {
        AttackState = 4;
    }

    // Start is called before the first frame update
    void Start()
    {
        movementScript = speedipillar.GetComponent<BasicPlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (AttackState)
        {
            case 0:
                break;
            case 1:
                Invoke("beginAttack", 3f);
                SetAttackState(2);
                break;
            case 2:
                transform.LookAt(speedipillar.transform.position);
                break;
            case 3:
                seekTarget = speedipillar.transform.position + speedipillar.transform.forward * advanceDistance;
                transform.LookAt(seekTarget);
                if(rb.velocity.magnitude < attackSpeed)
                {
                    rb.AddForce(transform.forward * attackAccel);
                }
                break;
            case 4:
                transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
                break;
        }
    }
}
