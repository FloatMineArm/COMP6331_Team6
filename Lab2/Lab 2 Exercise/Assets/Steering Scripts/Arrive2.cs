using UnityEngine;
using System.Collections;

public class Arrive2 : MonoBehaviour {

    public GameObject target;
    float acceleration = 2.0f;
    float speed = 20.0f;
    float nearSpeed = 10.0f;
    float nearRadius = 20.0f;
    float maxSpeed = 100.0f;
    float arrivalRadius = 10.0f;
    float distanceFromTarget;
    Vector3 currentVelocity;
    float timeToTarget = 0f;

    float nearSpeedCap = 50.0f;
    float arriveSpeedCap = 0.0f;
    float punchFactor = 50.0f;

    void PunchSelfInFace()
    {
        GetComponent<Rigidbody>().AddForce((target.transform.position - transform.position).normalized*punchFactor, ForceMode.Force);
    }

    void Update()
    {
        //calculate the distance from your target and check it against the various radii, have 
        //used the different speed constants to slow down and eventually stop as they are crossed.

        //THIS TIME THOUGH, you're doing it with acceleration.
        //This means that you're not only using a different velocity, but you are applying
        //a larger "breaking" acceleration that's meant to slow down your object quickly.
        //You can make use of the PunchSelfInFace() to accomplish this when the various radii
        //of interest are crossed.
        distanceFromTarget = (target.transform.position - transform.position).magnitude;
        currentVelocity = GetComponent<Rigidbody>().velocity;
        if(distanceFromTarget > nearRadius){
            if(currentVelocity.magnitude < maxSpeed){
                currentVelocity = (target.transform.position - transform.position).normalized * acceleration;
            }else{
                currentVelocity = (target.transform.position - transform.position).normalized * maxSpeed;
            }
        }
        else if(distanceFromTarget > arrivalRadius){
            GetComponent<Rigidbody>().velocity = (target.transform.position - transform.position).normalized * nearSpeed;
        }
        else{
            Debug.Log("Arrived");
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }
}
