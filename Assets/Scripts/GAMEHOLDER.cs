using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
using Random = UnityEngine.Random;

public class GAMEHOLDER : MonoBehaviour
{
    public string PutResult;
    private int Result;
    public GameObject ResultDisplayUI;
    public GameObject FinalResultDisplayCanvas;
  

    private int WhichHorseWin;
    public GameObject[] HORCES;
    float AvarageSpeed;
    public InputField ip;
    public GameObject InitialCanvas;
    //[Range(6, 9)]

    //public float FirstOneToThreeMin, FirstOneToThreeRangeMax, FirstFourToSixMin, FirstFourToSixMax, FirstLastMin, FirstLastMax;
    //[Range(6, 9)]
    //public float SecondOneToThreeMin, SecondOneToThreeRangeMax, SecondFourToSixMin, SecondFourToSixMax, SecondLastMin, SecondLastMax;

    //[Range(6, 9)]
    //public float ThirdOneToThreeMin, ThirdOneToThreeRangeMax, ThirdFourToSixMin, ThirdFourToSixMax, ThirdLastMin, ThirdLastMax;


    [Range(6, 9)]
    public float MaxSpeed,MinSpeed;


    public int timer;

    private List<int> First10Seconds = new List<int>();

    private int count;

    public GameObject EndPoint, RefrencePoint;

    public GameObject[] PosText;

    public GameObject[] Cameras;

    public String[] args;


   
   public int SeedValue = 111111;
    public Dictionary<String, float> HorsePositions = new Dictionary<string, float>();

    public GameObject[] objPosition;
    public Sprite[] JersyImages;


  public bool Time1,Time2,Time3, Time4;

    private void Awake()
    {

        GLOBAL.IsParticaleOn = false;

        FinalResultDisplayCanvas.SetActive(false);


        GLOBAL.DATE = "";
        GLOBAL.TIME = "";
        GLOBAL.ISLastTriggerHit = false;

        InitialCanvas.transform.GetChild(0).gameObject.SetActive(false);
        InitialCanvas.transform.GetChild(1).gameObject.SetActive(false);
        ResultDisplayUI.SetActive(false);
        Result = int.Parse(PutResult);
    






    }


    // Start is called before the first frame update
    void Start()
    {
      
        GLOBAL.H10_avgSpeed = GLOBAL.H9_avgSpeed = GLOBAL.H8_avgSpeed = GLOBAL.H7_avgSpeed = GLOBAL.H6_avgSpeed = GLOBAL.H5_avgSpeed = GLOBAL.H4_avgSpeed = GLOBAL.H3_avgSpeed = GLOBAL.H2_avgSpeed = GLOBAL.H1_avgSpeed = 0f;


#if UNITY_EDITOR
 
       Random.seed = SeedValue;
#elif UNITY_STANDALONE
        args = Environment.GetCommandLineArgs();
        SeedValue = int.Parse(args[2]);
      Random.seed = SeedValue;
#endif

        CrateRandomSpeed(MinSpeed, MaxSpeed);



    }

    public void GameStart()
    {


#if UNITY_EDITOR
        GLOBAL.DATE = DateTime.UtcNow.ToString("MM-dd-yyyy");
        GLOBAL.TIME = DateTime.Now.ToString("h:mm tt");


        //   GLOBAL.DATE_TIME=
        Result = int.Parse(PutResult);
        Invoke("LL", 1.7f);
        //   Debug.Log(GLOBAL.TIME);
#elif UNITY_STANDALONE
         GLOBAL.DATE=args [3]; 
        GLOBAL.TIME=args [4]+" "+ args [5];
         Result = int.Parse(args [1]);
        Invoke("LL", 1.7f);
#endif

        count = 0;


        float Dist = Vector3.Distance(RefrencePoint.transform.position, EndPoint.transform.position);
        GLOBAL.F_HORSETIME = Dist / GLOBAL.F_HORSEMAXSPEED;
        GLOBAL.S_HORSETIME = Dist / GLOBAL.S_HORSEMAXSPEED;
        GLOBAL.T_HORSETIME = Dist / GLOBAL.T_HORSEMAXSPEED;


        GLOBAL.TagAssign = true;
   
  //      CrateRandomSpeed(MinSpeed, MaxSpeed);
        

        
    }


    public void CrateRandomSpeed(float  Min ,float Max)
    {
       


        GLOBAL.H1_avgSpeed = Random.Range(Min, Max);
        GLOBAL.H2_avgSpeed = Random.Range(Min, Max);
        GLOBAL.H3_avgSpeed =Random.Range(Min, Max);

        GLOBAL.H4_avgSpeed = Random.Range(Min, Max);
        GLOBAL.H5_avgSpeed = Random.Range(Min, Max);
        GLOBAL.H6_avgSpeed = Random.Range(Min, Max);

        GLOBAL.H7_avgSpeed = Random.Range(Min, Max);
        GLOBAL.H8_avgSpeed = Random.Range(Min, Max);
        GLOBAL.H9_avgSpeed = Random.Range(Min, Max);
        GLOBAL.H10_avgSpeed = Random.Range(Min, Max);



        HORCES[0].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H1_avgSpeed;
        HORCES[1].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H2_avgSpeed;
        HORCES[2].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H3_avgSpeed;
        HORCES[3].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H4_avgSpeed;
        HORCES[4].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H5_avgSpeed;
        HORCES[5].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H6_avgSpeed;
        HORCES[6].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H7_avgSpeed;
        HORCES[7].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H8_avgSpeed;
        HORCES[8].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H9_avgSpeed;
        HORCES[9].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H10_avgSpeed;
        Debug.Log(GLOBAL.H1_avgSpeed + "  " + GLOBAL.H2_avgSpeed + "  " + GLOBAL.H3_avgSpeed + "  " + GLOBAL.H4_avgSpeed + "  " + GLOBAL.H5_avgSpeed + "  " + GLOBAL.H6_avgSpeed + "  " + GLOBAL.H7_avgSpeed + "  " + GLOBAL.H8_avgSpeed + "  " + GLOBAL.H9_avgSpeed + "  " + GLOBAL.H10_avgSpeed + "  ");



    }

    public void CreateRandomList(float FirstMin, float FirstMax, float SecondMin, float SecondMax, float ThirdMin, float ThirdMax)
    {

        First10Seconds.Clear();
        do
        {
            int Number = UnityEngine.Random.Range(0, 10);
            while (!First10Seconds.Contains(Number))
                First10Seconds.Add(Number);
        }
        while (First10Seconds.Count < 10);

        GLOBAL.H1_avgSpeed = UnityEngine.Random.Range(FirstMin, FirstMax);
        GLOBAL.H2_avgSpeed = UnityEngine.Random.Range(FirstMin, FirstMax);
        GLOBAL.H3_avgSpeed = UnityEngine.Random.Range(FirstMin, FirstMax);

        GLOBAL.H4_avgSpeed = UnityEngine.Random.Range(SecondMin, SecondMax);
        GLOBAL.H5_avgSpeed = UnityEngine.Random.Range(SecondMin, SecondMax);
        GLOBAL.H6_avgSpeed = UnityEngine.Random.Range(SecondMin, SecondMax);

        GLOBAL.H7_avgSpeed = UnityEngine.Random.Range(ThirdMin, ThirdMax);
        GLOBAL.H8_avgSpeed = UnityEngine.Random.Range(ThirdMin, ThirdMax);
        GLOBAL.H9_avgSpeed = UnityEngine.Random.Range(ThirdMin, ThirdMax);
        GLOBAL.H10_avgSpeed = UnityEngine.Random.Range(ThirdMin, ThirdMax);


        //HORCES[First10Seconds[0]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H1_avgSpeed;
        //HORCES[First10Seconds[1]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H2_avgSpeed;
        //HORCES[First10Seconds[2]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H3_avgSpeed;
        //HORCES[First10Seconds[3]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H4_avgSpeed;
        //HORCES[First10Seconds[4]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H5_avgSpeed;
        //HORCES[First10Seconds[5]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H6_avgSpeed;
        //HORCES[First10Seconds[6]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H7_avgSpeed;
        //HORCES[First10Seconds[7]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H8_avgSpeed;
        //HORCES[First10Seconds[8]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H9_avgSpeed;
        //HORCES[First10Seconds[9]].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H10_avgSpeed;


        HORCES[0].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H1_avgSpeed;
        HORCES[1].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H2_avgSpeed;
        HORCES[2].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H3_avgSpeed;
        HORCES[3].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H4_avgSpeed;
        HORCES[4].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H5_avgSpeed;
        HORCES[5].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H6_avgSpeed;
        HORCES[6].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H7_avgSpeed;
        HORCES[7].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H8_avgSpeed;
        HORCES[8].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H9_avgSpeed;
        HORCES[9].gameObject.transform.GetComponent<SpeedManager>().Speed = GLOBAL.H10_avgSpeed;

        Debug.Log(GLOBAL.H1_avgSpeed + "  " + GLOBAL.H2_avgSpeed + "  " + GLOBAL.H3_avgSpeed + "  " + GLOBAL.H4_avgSpeed + "  " + GLOBAL.H5_avgSpeed + "  " + GLOBAL.H6_avgSpeed + "  " + GLOBAL.H7_avgSpeed + "  " + GLOBAL.H8_avgSpeed + "  " + GLOBAL.H9_avgSpeed + "  " + GLOBAL.H10_avgSpeed + "  ");


    }    //not use


    public void LL()
    {
      
        // Result = int.Parse(ip.text);
        Win(Result);
        GLOBAL.IsStart = true;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().GameStart();
        ResultDisplayUI.SetActive(true);
        InvokeRepeating("DisplayCanvasNumberSlot", 0.5f, 0.5f);
    

        InitialCanvas.transform.GetChild(0).gameObject.SetActive(false);
        InitialCanvas.transform.GetChild(1).gameObject.SetActive(false);

        // InitialCanvas.SetActive(false);
    }

    public void Win(int input)
    {


        GLOBAL.FIRSTWIN = input / 100;
        GLOBAL.SECONDWIN = (input / 10) % 10;
        GLOBAL.THIRDWIN = input % 10;

        HORCES[GLOBAL.FIRSTWIN ].transform.gameObject.tag = "1";

        HORCES[GLOBAL.SECONDWIN ].transform.gameObject.tag = "2";


        HORCES[GLOBAL.THIRDWIN ].transform.gameObject.tag = "3";

        int r = 3;
        for (WhichHorseWin = 0; WhichHorseWin < 10; WhichHorseWin++)
        {
            if (GLOBAL.FIRSTWIN != WhichHorseWin  && GLOBAL.SECONDWIN != WhichHorseWin  && GLOBAL.THIRDWIN != WhichHorseWin )

            {
                r++;
                HORCES[WhichHorseWin].gameObject.tag = (r).ToString();

            }



        }

        GLOBAL.GAMESTART = true;
        StartCoroutine("MainCameraStop");
        //Set Replay canvas result images
        objPosition[0].transform.GetChild(0).GetComponent<Image>().sprite = JersyImages[GLOBAL.FIRSTWIN];
        objPosition[1].transform.GetChild(0).GetComponent<Image>().sprite = JersyImages[GLOBAL.SECONDWIN];
        objPosition[2].transform.GetChild(0).GetComponent<Image>().sprite = JersyImages[GLOBAL.THIRDWIN];




        objPosition[0].transform.GetChild(1).GetComponent<Text>().text =/*(1+ GLOBAL.FIRSTWIN).ToString()*/(GLOBAL.FIRSTWIN + 1) == 10 ? "Z" : (GLOBAL.FIRSTWIN + 1).ToString(); 
        objPosition[1].transform.GetChild(1).GetComponent<Text>().text =/*(1+ GLOBAL.SECONDWIN).ToString();*/(GLOBAL.SECONDWIN + 1) == 10 ? "Z" : (GLOBAL.SECONDWIN + 1).ToString();
        objPosition[2].transform.GetChild(1).GetComponent<Text>().text =/*(1+GLOBAL.THIRDWIN).ToString();*/(GLOBAL.THIRDWIN + 1) == 10 ? "Z" : (GLOBAL.THIRDWIN + 1).ToString();

        GLOBAL.IsParticaleOn = true;

    }

    IEnumerator MainCameraStop()
    {
        yield return new WaitForSeconds(1f);
        Cameras[0].SetActive(false);
        Cameras[1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
     
    }



    // Update is called once per frame
    void Update()
    {
        timer = GLOBAL.Timer;
    
        // AvarageSpeed=Mathf.Max()
        if (GLOBAL.Timer == 10&& Time1==false)
        {
            Time1 = true;
            //  CreateRandomList(SecondOneToThreeMin, SecondOneToThreeRangeMax, SecondFourToSixMin, SecondFourToSixMax, SecondLastMin, SecondLastMax);
            CrateRandomSpeed(MinSpeed, MaxSpeed);
        }
        else if (GLOBAL.Timer == 20 && Time2==false)
        {
            Time2 = true;
            //   CreateRandomList(ThirdOneToThreeMin, ThirdOneToThreeRangeMax, ThirdFourToSixMin, ThirdFourToSixMax, ThirdLastMin, ThirdLastMax);
            CrateRandomSpeed(MinSpeed, MaxSpeed);
        }
        else if (GLOBAL.Timer == 30 && Time3==false)
        {
            Time3 = true;
            CrateRandomSpeed(MinSpeed, MaxSpeed);
        }
        else if (GLOBAL.Timer == 40 && Time4 == false)
        {
            Time4 = true;
            CrateRandomSpeed(MinSpeed, MaxSpeed);
        }
        // DisplayCanvasNumberSlot();


    }


    public void DisplayCanvasNumberSlot()
    {
        string Name = "";

        bool isLoopStart = true;
        if (isLoopStart)
        {
            isLoopStart = false;
            int index = 9;
            foreach (KeyValuePair<string, float> author in HorsePositions.OrderBy(key => key.Value))
            {

                //  PosText[index].text = author.Key;
                if (author.Key != "Z")
                {
                    PosText[index].transform.GetChild(0).GetComponent<Image>().sprite = JersyImages[int.Parse(author.Key) - 1];
                    PosText[index].transform.GetChild(1).GetComponent<Text>().text = author.Key;
                }
                else
                {
                    PosText[index].transform.GetChild(0).GetComponent<Image>().sprite = JersyImages[9];
                    PosText[index].transform.GetChild(1).GetComponent<Text>().text = "Z";
                }
                index--;

                Name += (author.Key).ToString() + " == " + +author.Value + ",";


            }
         //     Debug.Log(Name);
            isLoopStart = false;
        }



    }





    public void Ishit()
    {
        count++;
        if (count == 1)
        {
            foreach (var item in HORCES)
            {
                if (item.gameObject.tag == "1")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 7.8f;
                    Cameras[1].GetComponent<GLOBALCAMERAFOLLOW>().enabled = true;
                    GLOBAL.ISLastTriggerHit = true;
                }
                else if (item.gameObject.tag == "2")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 8f;
                }
                else if (item.gameObject.tag == "3")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 8.2f;
                }
                else if (item.gameObject.tag == "4")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 8.5f;
                }
                else if (item.gameObject.tag == "5")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 8.9f;
                }
                else if (item.gameObject.tag == "6")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 9.0f;
                }
                else if (item.gameObject.tag == "7")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 9.2f;
                }
                else if (item.gameObject.tag == "8")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 9.4f;
                }
                else if (item.gameObject.tag == "9")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 9.5f;
                }
                else if (item.gameObject.tag == "10")
                {
                    float Dist = Vector3.Distance(item.transform.position, EndPoint.transform.position);
                    item.transform.GetComponent<SpeedManager>().Speed = Dist / 9.6f;
                }
            }

        }

    }


    }



