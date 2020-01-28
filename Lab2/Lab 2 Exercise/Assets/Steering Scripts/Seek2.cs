using UnityEngine;
using System.Collections;

public class Seek2 : MonoBehaviour {

    public GameObject target;
    float acceleration = 2.0f;
    float maxSpeed = 100.0f;
    float distanceFromTarget;

    void Update()
    {

        //Seek should more TOWARD the target object.
        //in the steering version, just remember to enforce the maximum speed.
        if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed){
            GetComponent<Rigidbody>().velocity += (target.transform.position + transform.position).normalized * acceleration;
        }
        else{
            GetComponent<Rigidbody>().velocity = (target.transform.position + transform.position).normalized * maxSpeed;
        }
    }
}
