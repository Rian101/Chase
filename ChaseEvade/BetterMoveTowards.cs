using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BetterMoveTowards : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.0f;
    public float chaseRange = 6.0f;
   

    void Start()
    {
        

    }

    void Update()
    {
        float speedDelta = speed * Time.deltaTime;
        Vector3 newPosition = tusMoveTowards(speedDelta);

        transform.position = newPosition;
    }

    Vector3 tusMoveTowards(float sd)
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = target.transform.position;

        Vector3 rangeToClose = targetPosition - currentPosition;

        Debug.DrawRay(currentPosition, rangeToClose, Color.red);

        Vector3 newPosition;

        float magnitude = rangeToClose.magnitude;

        if (magnitude < chaseRange)
        {
            Vector3 normalisedRangeToClose = rangeToClose.normalized;
            Debug.DrawRay(currentPosition, normalisedRangeToClose, Color.green);

            Debug.Log("Magnitude: " + magnitude + " Direction: " + normalisedRangeToClose);


            Vector3 velocity = normalisedRangeToClose * sd;

            newPosition = currentPosition + velocity;
        }
        else
        {
            newPosition = currentPosition;
        }

        return newPosition;


    }

}
