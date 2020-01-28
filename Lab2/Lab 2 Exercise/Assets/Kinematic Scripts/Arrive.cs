using UnityEngine;
using System.Collections;

public class Arrive : MonoBehaviour {

    public GameObject target;
    float speed = 20.0f;
    float nearSpeed = 10.0f;
    float nearRadius = 20.0f;
    float arrivalRadius = 10.0f;
    float distanceFromTarget;

    void Update()
    {
        //calculate the distance from your target and check it against the various radii, have 
        //used the different speed constants to slow down and eventually stop as they are crossed.
        distanceFromTarget = (target.transform.position - transform.position).magnitude;

        if(distanceFromTarget > nearRadius){
            GetComponent<Rigidbody>().velocity = (target.transform.position - transform.position).normalized * speed;
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
