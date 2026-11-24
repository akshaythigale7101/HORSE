using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalesEffect : MonoBehaviour
{
    public GameObject Particaleobj1, Particaleobj2;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(GLOBAL.IsParticaleOn)
        {
          
            Particaleobj1.SetActive(true);
            Particaleobj2.SetActive(true);
        }
        else
        {
       
            Particaleobj1.SetActive(false);
            Particaleobj2.SetActive(false);

        }

    }


    //public void ParticaleOn()
    //{
        
    //}


    //public void Paricalesoff()
    //{
        
    //}



}
