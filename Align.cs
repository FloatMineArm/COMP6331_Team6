using UnityEngine;
using System.Collections;

public class Align : MonoBehaviour {

    /*
    *  In the Kinematic version of the Align behaviour, an initial facing, goal facing, and speed 
    *  are needed.  While it's possible to program rotation via tracking and applying angular velocity, you would essentially be re-doing
    *  work that's already present in Unity.  Rigidbodies save time, and Quaternions represent rotation neatly.
    * 
    * Quaternion.LookRotation -> generates a rotation representation
    * Quaternion.RotateTowards -> incrementally rotates the heading of the object toward the vector it's passed.
    *    
    */

    public GameObject target;
    public bool hasTarget;
    Quaternion lookWhereYoureGoing;

    Vector3 goalFacing;
    float orientationRads;
    float rotationSpeedRads;
    void Start() {
        rotationSpeedRads = 1.0f;
    }
    void Update() {
        if (hasTarget)
        {
            //Figure out where you want to face, then use the mentioned functions to make it happen
            goalFacing = (target.transform.position - transform.position).normalized;
            lookWhereYoureGoing = Quaternion.LookRotation(goalFacing, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookWhereYoureGoing, rotationSpeedRads);
        }
        else
        {
            //When the unit has no target, just have its goal facing be it's transform.forward direction.
            //goalFacing = getComponent<Rigidbody>().velocity.normalized;
            //lookWhereYoureGoing = Quaternion.LookRotation
        }
    }
}