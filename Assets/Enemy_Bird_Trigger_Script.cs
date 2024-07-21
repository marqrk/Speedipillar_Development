using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird_Trigger_Script : MonoBehaviour
{

    public GameObject bird;
    public GameObject Speedipillar;
    BasicPlayerMovement movescript;

    private void Start()
    {
        movescript = Speedipillar.GetComponent<BasicPlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == Speedipillar.name)
        {
            bird.GetComponent<Enemy_Bird_Script>().SetAttackState(1);
        }
    }
}
