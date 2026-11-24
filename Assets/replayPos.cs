using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replayPos : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "FinalBlow")
        {
          
            if (!GLOBAL.getReplayPos)
            {
               
                GLOBAL.getReplayPos = true;
            }
      
        //    Debug.Log("Reply Trigger Speed of " + other.gameObject.transform.parent.name + " is " + other.gameObject.transform.parent.GetComponent<SpeedManager>().Speed);



        }

    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
