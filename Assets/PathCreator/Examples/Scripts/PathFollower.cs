using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
         public float speed ;
      [HideInInspector] public float distanceTravelled;
        bool replayStartPosition;
        float replayStartDistance;

        private struct ReplayPositions
        {
         
            public Vector3 position;
            public Quaternion rotation;
            public float speed;

            public ReplayPositions( Vector3 currentPos, Quaternion currentrot, float currentSpeed)
            {               
                position = currentPos;
                rotation = currentrot;
                speed = currentSpeed;
            }
        }
        static List<ReplayPositions> replayList = new List<ReplayPositions>();
        void Start()
        {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
            replayList.Clear();
            replayStartPosition = true;
        }

        void Update()
        {
            
           if (GLOBAL.IsStart)
            {
                GLOBAL.Timer=((int)(Time.time));
                if (pathCreator != null)              
                {
                    if (!GLOBAL.startReplay)
                    {
                   


                        distanceTravelled += speed * Time.deltaTime;
                        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                        if (GLOBAL.getReplayPos)
                        {

                            if (replayStartPosition)
                            {
                                replayStartDistance = distanceTravelled;
                                replayStartPosition = false;
                            }
                        }


                    }
                    else
                    {
                       // Time.timeScale = 0.1f;
                        replayStartDistance += speed * Time.deltaTime;
                        transform.position = pathCreator.path.GetPointAtDistance(replayStartDistance, endOfPathInstruction);
                        transform.rotation = pathCreator.path.GetRotationAtDistance(replayStartDistance, endOfPathInstruction);
                    }


                }

            }

            


        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}