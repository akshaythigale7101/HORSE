using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("START GAme");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().t21Go();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Start")
            {
          //  Debug.Log("START GAme");
            GameObject.Find("GAMEHOLDR").GetComponent<GAMEHOLDER>().GameStart();
      
        }
    }
}
