using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top3Move : MonoBehaviour
{

    public GameObject ReferanceObject;
   public float TIme;
    private void Start()
    {
     

    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "FinalBlow")
        {
            GLOBAL.LastRound = true;
            GameObject.Find("GAMEHOLDR").transform.GetComponent<GAMEHOLDER>().Ishit();
         //   Debug.Log("First Trigger Speed of " + other.gameObject.transform.parent.name + " is " + other.gameObject.transform.parent.GetComponent<SpeedManager>().Speed);

          //  GLOBAL.Last = true;
        }

    }
}
