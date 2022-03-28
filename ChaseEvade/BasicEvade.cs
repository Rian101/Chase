using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEvade : MonoBehaviour

{
    public GameObject target;
    public float speed = 1.0f;
    public float chaseRange = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    

    // Update is called once per frame
    void Update()
    {
        float speedDelta = speed * Time.deltaTime;
        // Use Unity's Vector3.moveTowards
        //Vector3 newPosition = Vector3.MoveTowards(transform.position, target.transform.position, speedDelta);        
        // Write our own aitMoveTorwards
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

        // Get the magnitude of the vector
        float magnitude = rangeToClose.magnitude;

        if (magnitude < chaseRange)
        {
            Vector3 normalisedRangeToClose = rangeToClose.normalized;
            Debug.DrawRay(currentPosition, normalisedRangeToClose, Color.green);

            Debug.Log("Magnitude: " + magnitude + " Direction: " + normalisedRangeToClose);

            // Move speedDelta along the normalisedRangeToClose direction
            Vector3 velocity = normalisedRangeToClose * sd;

            newPosition = currentPosition - velocity;
        }
        else
        {
            newPosition = currentPosition;
        }

        return newPosition;

        /*// Calculate our range to close i.e. the vector between
        // our enemy and the target
        Vector3 rangeToClose = targetPosition - currentPosition;
        Debug.DrawRay(currentPosition, rangeToClose, Color.red);

        // Get the magnitude of the vector
        float magnitude = rangeToClose.magnitude;

        Vector3 newPosition;

        if (magnitude < chaseRange)
        {
            // Get the direction only
            Vector3 normalisedRangeToClose = rangeToClose.normalized;
            Debug.DrawRay(currentPosition, normalisedRangeToClose, Color.green);

            Debug.Log("Magnitude: " + magnitude + " Direction: " + normalisedRangeToClose);

            // Move speedDelta along the normalisedRangeToClose direction
            Vector3 velocity = normalisedRangeToClose * sd;

            newPosition = currentPosition + velocity;
        }
        else
        {
            newPosition = currentPosition;
        }

        return newPosition;*/
        //return transform.position;
    }
}
