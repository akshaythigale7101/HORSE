using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalBlowTriger : MonoBehaviour
{


    public static int count=0;
    public Text[] Results;
    public GameObject finishlineCamera,replayCamera;
    public GameObject replayCanvas;
    public GameObject positionDisplay;
    int countHorse = 0;
    
  //  public GameObject[] objPosition;
    private void Start()
    {
        
         

    }

    private void OnTriggerEnter(Collider other)
    {       
            if (other.gameObject.tag == "FinalBlow")
            {
            if (!GLOBAL.startReplay)
            {           
                GLOBAL.Last = false;
                count++;
            } else
            {
             
                if (countHorse < 3)
                {
                  
                    StartCoroutine(ReplayResultPause());
                   GameObject.Find("GAMEHOLDR").GetComponent<GAMEHOLDER>().objPosition[countHorse].SetActive(true);
                    countHorse++;
                }else
                {
                    StopCoroutine(ChangeCamera());
                    StopCoroutine(ReplayResultPause());
                    DisplayResultCanvasOn();
              
                }
            }




          
            }

        if (count == 5)
        {

            StartCoroutine(ChangeCamera());

        }
        //{

        //    StartCoroutine(ReplayResultPause());
        //    objPosition[countHorse].SetActive(true);
        //    countHorse++;
        //}else
        //{
        //    Time.timeScale = 1;
        //}
    }

    public void DisplayResultCanvasOn()
    {
        GameObject.Find("GAMEHOLDR").GetComponent<GAMEHOLDER>().FinalResultDisplayCanvas.SetActive(true);
    }


    IEnumerator ChangeCamera()
    {
   //     yield return new WaitForSeconds(1f);

        GLOBAL.IsParticaleOn = false;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().GameStop();
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.1f;
        replayCamera.SetActive(true);
        GLOBAL.startReplay = true;
        replayCanvas.SetActive(true);
        positionDisplay.SetActive(false);
        finishlineCamera.SetActive(false);
        GLOBAL.getReplayPos = false;
    }
    IEnumerator ReplayResultPause()
    {
        Time.timeScale = 0.00001f;
        yield return new WaitForSeconds(0.00002f);
        Time.timeScale = 0.1f;
    }
}
