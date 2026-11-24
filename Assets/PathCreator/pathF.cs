using PathCreation;
using UnityEngine;

public class pathF : MonoBehaviour
{
public PathCreator pathCreator;
public float speed=5f;
float distanceTravelled;
public Vector3 offset;
    public int i = 0;

    private void Start()
    {
        Reapeattask();
        Debug.Log(pathCreator.path.NumPoints);
    }
    void Update() {

      
   //     distanceTravelled +=speed*Time.deltaTime;
  //  transform.position=pathCreator.path.GetPointAtDistance(distanceTravelled)+offset;
 //   transform.rotation=pathCreator.path.GetRotationAtDistance(distanceTravelled);
        }

    public void Reapeattask()
    {

        i++;
        //pathCreator.path.localPoints
     //  transform.position = pathCreator.path.GetNormal(i);
        //    InvokeRepeating("Reapeattask", 1, 1);
      //  Debug.Log(pathCreator.path.length);
        Invoke("Reapeattask", 1);
    }

}
