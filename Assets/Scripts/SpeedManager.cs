using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;
using Random = UnityEngine.Random;

public class SpeedManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PathFollower pathFollower;

    public float Speed;
    public GameObject[] ReferanceObject;
    private Animator Anim;
    public float Distance;
    public GAMEHOLDER gameholder;
   public  AudioSource Audio;
    public bool StopCalculatingDistance;




    private void Awake()
    {
        Random.seed = 1;
        Anim = GetComponent<Animator>();
        pathFollower = GetComponent<PathFollower>();
        Audio = GetComponent<AudioSource>();
    }
    void Start()
    {

        StopCalculatingDistance = true;


    }
  
    // Update is called once per frame
    void Update()
    {if (StopCalculatingDistance)
        {
            Distance = Vector3.Distance(Vector3.zero,this.gameObject.transform.position);// Vector3.Distance(this.gameObject.transform.position, ReferanceObject[0].gameObject.transform.position);
                                                                                         //    Debug.Log("FIRst");
            if (this.gameObject.name == "1")
            {
              //  Debug.Log("====>>>>  First   ===  "+Distance);


            }


        }
    else
        {
 
          //  Debug.Log("SECOND");
            Distance = Vector3.Distance(Vector3.zero,this.gameObject.transform.position);
            if (this.gameObject.name == "1")
            {
              //  Debug.Log("====>>>>  Second   ===  " + Distance);


            }
        }
        if(gameholder.HorsePositions.ContainsKey(this.gameObject.name))
        {
            gameholder.HorsePositions[this.gameObject.name] = Distance;
        }
        else
        {
            gameholder.HorsePositions.Add(this.gameObject.name, Distance);
        }

        


        Anim.SetBool("Start", GLOBAL.IsStart);

        


        pathFollower.speed = Speed;

        if(Speed>6.5f && Speed<7f)
        {
            Anim.SetFloat("SpeedMul", 1.30f);
        }
        else if (Speed > 7f && Speed < 7.3f)
        {
            Anim.SetFloat("SpeedMul", 1.45f);
        }
        else if (Speed > 7.3f && Speed < 7.6f)
        {
            Anim.SetFloat("SpeedMul", 1.55f);
        }
        else if (Speed > 7.6f && Speed < 8.3f)
        {
            Anim.SetFloat("SpeedMul", 1.60f);
        }
        else if (Speed > 8.3f && Speed < 10f)
        {
            Anim.SetFloat("SpeedMul", 1.70f);
        }
        else
        {
            Anim.SetFloat("SpeedMul", 1.72f);

        }





    }

    public void LastHitMethod()
    {
        

    }




}

