using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCameraRotate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "FinalBlow")
        {

            GLOBAL.CameraRotateTrigger = true;
        }
    }
}
