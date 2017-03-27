using UnityEngine;
using System.Collections;

public class MoveableObjectManager : MonoBehaviour
{

    public AIBirdMotion moveableObject;
    public Transform point1;
    public Transform point2;
    public float timeInSeconds;
    public Quaternion initRotation;
    public Quaternion angle;

    void Start()
    {
        // moveableObject.setNewDestination(point1, point2);
    }

    void Update()
    {
        if (timeInSeconds > 0.0f)
        {
            timeInSeconds -= Time.deltaTime;
            if (!moveableObject.isMoving)
            {
                if (moveableObject.transform.position == point2.position)
                {
                    moveableObject.setNewDestination(point2, point1);
                    moveableObject.transform.rotation = angle;
                }
                else if (moveableObject.transform.position == point1.position)
                {
                    moveableObject.setNewDestination(point1, point2);
                    moveableObject.transform.rotation = initRotation;
                }
            }
        }
        else
        {
            //end of loop for this MoveableObject
        }
    }
}