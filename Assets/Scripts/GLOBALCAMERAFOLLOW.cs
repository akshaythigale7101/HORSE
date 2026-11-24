using UnityEngine;
using System.Collections;

public class GLOBALCAMERAFOLLOW : MonoBehaviour {
	private Transform target;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (GLOBAL.CameraRotateTrigger)
        {
           target = GameObject.FindGameObjectWithTag("1").transform.GetChild(2).gameObject.transform;
            Vector3 Reletivepos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Reletivepos, Vector3.up);
            transform.rotation = rotation;
           // transform.rotation.y =Quaternion.a 0f;
        }
	}
}
