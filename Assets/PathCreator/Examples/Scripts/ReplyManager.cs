using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PathCreation.Examples
{
public class ReplyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> pos = new List<Vector3>();
    public List<Quaternion> Rot = new List<Quaternion>();
    public List<float> Speed = new List<float>();
    public bool IsRecording;
    public CubeFollow cubeFollow;
        public bool Reply;
        public float speed;

    private void Start()
    {
        IsRecording = false;
    }



    private void OnTriggerEnter(Collider other)
    {
    if(other.gameObject.tag=="1")
            {
                IsRecording = true;
            }
    if(other.gameObject.tag=="2")
            {
                IsRecording = false;
            }



    
    }
    private void Update()
    {
        if (IsRecording)
        {
            pos.Add(transform.position);
            Rot.Add(transform.rotation);
            Speed.Add(cubeFollow.speed);
        }

            if (Reply)
            {
                IsRecording = false;
                cubeFollow.enabled = false;
                {
                    float step = speed * Time.deltaTime;
                    transform.localPosition = Vector3.MoveTowards(pos[0], pos[pos.Count - 100], step);
                    
                }
            }

        
    }

    IEnumerator ReplySystem()
        {

        
            yield return new WaitForSeconds(0.2f);

            //for (int i = 0; i < pos.Count; i++)
            //{
            //            //    Debug.Log(transform.position);
            //    transform.position = Vector3.left();// * Time.deltaTime * sped;
            //}


        }

    } }
