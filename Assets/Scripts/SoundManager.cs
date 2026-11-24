using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource HorseFootSteps;
    public AudioSource Comentry;
    public AudioSource t21go;

    
    public void t21Go()
    {
        t21go.Play();
    }
    public void GameStart()
    {
      
        Comentry.Play();
        for (int i = 0; i < GameObject.Find("GAMEHOLDR").transform.GetComponent<GAMEHOLDER>().HORCES.Length; i++)
        {
            GameObject.Find("GAMEHOLDR").transform.GetComponent<GAMEHOLDER>().HORCES[i].GetComponent<SpeedManager>().Audio.Play();
        }
    }
    public void GameStop()
    {
        Comentry.Stop();
        for (int i = 0; i < GameObject.Find("GAMEHOLDR").transform.GetComponent<GAMEHOLDER>().HORCES.Length; i++)
        {
            GameObject.Find("GAMEHOLDR").transform.GetComponent<GAMEHOLDER>().HORCES[i].GetComponent<SpeedManager>().Audio.Stop();
        }
    }


}
