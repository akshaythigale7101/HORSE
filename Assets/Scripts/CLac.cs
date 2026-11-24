using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLac : MonoBehaviour
{
    public int Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GLOBAL.Last)
        {
            Timer = 0;
            Timer = (int)(Time.time);
        }
        
    }
}
