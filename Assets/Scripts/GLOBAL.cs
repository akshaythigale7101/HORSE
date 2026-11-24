using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GLOBAL

{
    public static int FIRSTWIN { get; set; }
    public static int SECONDWIN { get; set; }
    public static int THIRDWIN { get; set; }
    public static bool TagAssign { get; set; }
    public static bool LastRound { get; set; }


    public static bool Last{ get; set; }
    public static bool IsStart { get; set; }

    public static bool GAMESTART { get; set; }

    public static bool ISLastTriggerHit { get; set; }


    public static float H1_avgSpeed { get; set; }
    public static float H2_avgSpeed { get; set; }
    public static float H3_avgSpeed { get; set; }
    public static float H4_avgSpeed { get; set; }
    public static float H5_avgSpeed { get; set; }
    public static float H6_avgSpeed { get; set; }
    public static float H7_avgSpeed { get; set; }
    public static float H8_avgSpeed { get; set; }
    public static float H9_avgSpeed { get; set; }
    public static float H10_avgSpeed { get; set; }
    public static int Timer { get; set; }


    public static float F_HORSETIME;//=4.375f;
    public static float S_HORSETIME;// = 3.269f;
    public static float T_HORSETIME; //= 3.355f;


    public const float F_HORSEMAXSPEED = 8.6f;
    public const float S_HORSEMAXSPEED = 8.2f;
    public const float T_HORSEMAXSPEED = 8f;
    public const float T_HORSEAVGSPEED = 7.3f;

    public static bool startReplay = false;
    public static bool getReplayPos = false;

    public static string DATE = "";
    public static string TIME = "";

    public static bool IsParticaleOn { get; set; }
    public static bool THREE_TWO_ONE_GO { get; set; }
    public static bool CameraRotateTrigger{ get; set; }
}
