using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();

    }


    private void Update()
    {
        if(GLOBAL.IsStart)
        {
            Anim.SetBool("GateOpen", GLOBAL.IsStart);
        }
    }
}
