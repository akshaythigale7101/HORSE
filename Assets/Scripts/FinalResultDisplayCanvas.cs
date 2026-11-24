using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class FinalResultDisplayCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] TOP3;
    public Text Timetext, DateText;
    public Sprite[] HorseImages;
    


    public void DisplayFinalResult()
    {
        TOP3[0].transform.GetChild(0).GetComponent<Image>().sprite = GameObject.Find("GAMEHOLDR").GetComponent<GAMEHOLDER>().JersyImages[GLOBAL.FIRSTWIN];
        TOP3[1].transform.GetChild(0).GetComponent<Image>().sprite = GameObject.Find("GAMEHOLDR").GetComponent<GAMEHOLDER>().JersyImages[GLOBAL.SECONDWIN];
        TOP3[2].transform.GetChild(0).GetComponent<Image>().sprite = GameObject.Find("GAMEHOLDR").GetComponent<GAMEHOLDER>().JersyImages[GLOBAL.THIRDWIN];


        TOP3[0].transform.GetChild(1).GetComponent<Text>().text = (GLOBAL.FIRSTWIN + 1) == 10 ? "Z" : (GLOBAL.FIRSTWIN + 1).ToString();
        TOP3[1].transform.GetChild(1).GetComponent<Text>().text = (GLOBAL.SECONDWIN + 1) == 10 ? "Z" : (GLOBAL.SECONDWIN + 1).ToString();
        TOP3[2].transform.GetChild(1).GetComponent<Text>().text = (GLOBAL.THIRDWIN + 1) == 10 ? "Z" : (GLOBAL.THIRDWIN + 1).ToString();

        TOP3[0].transform.GetChild(3).GetComponent<Image>().sprite = (GLOBAL.FIRSTWIN % 2 == 0) ? HorseImages[0] : HorseImages[1];
    //    TOP3[1].transform.GetChild(3).GetComponent<Image>().sprite = (GLOBAL.SECONDWIN % 2 == 0) ? HorseImages[0] : HorseImages[1];
      //  TOP3[2].transform.GetChild(3).GetComponent<Image>().sprite = (GLOBAL.THIRDWIN% 2 == 0) ? HorseImages[0] : HorseImages[1];



        Timetext.text = GLOBAL.TIME;
        DateText.text = GLOBAL.DATE;


        Invoke("QuitGame", 0.2f);
    }

    private void OnEnable()
    {
        DisplayFinalResult();
       

    }
    public void QuitGame()
    {

        Debug.Log("Application Quit");

        Application.Quit();
    }

    

}
