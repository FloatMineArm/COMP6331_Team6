using UnityEngine;
using System.Collections;

public class Align2 : MonoBehaviour {

    public GameObject target;
    Quaternion lookWhereYoureGoing;

    Vector3 goalFacing;
    public float orientationRads;
    public float rotationSpeedRads;
    public float slowDownThreshold;
    public float goalRotationSpeedRads;
    public float maxRotationSpeedRads;
    public float maxRotationAccelerationRads;
    public float accelerationRads;
    public float timeToTarget;



    void Start()
    {
        slowDownThreshold = 5.0f;
        maxRotationSpeedRads = 2.0f;
        maxRotationAccelerationRads = 1.0f;
        goalRotationSpeedRads = 0.0f;
        rotationSpeedRads = 0.0f;
        accelerationRads = 0.1f;
        timeToTarget = 0.0f;
    }
    void Update()
    {

        //we generate a goal facing, just like last time
        goalFacing = (target.transform.position - transform.position).normalized;

        //next we generate a speed that we would like to reach
        //this is a constant multiplied by the difference between our current angle and our goal angle.
        goalRotationSpeedRads = maxRotationSpeedRads * Vector3.Angle(goalFacing, this.transform.forward) / slowDownThreshold;

        //next we calculate the time it will take to reach the target facing, given our present rotational speed.
        // timeToTarget = angle between forward&goal vectors, divided by our rotation speed.
        //don't forget to check if the rotation speed is 0!  If it is, our default case will be to set time to target = 0.1.
        if (rotationSpeedRads != 0.0f)
        {
            timeToTarget =  Vector3.Angle(goalFacing, this.transform.forward) / rotationSpeedRads;
        }
        else
        {
            timeToTarget = 0.1f;
        }

        //given all the variables we have calculated so far, calculate the radial acceleration according
        //to the formula found in the class slides.
        accelerationRads = (goalRotationSpeedRads - rotationSpeedRads) / timeToTarget;

        //enforce the max rotational acceleration
        if (accelerationRads >= maxRotationAccelerationRads)
        {
            accelerationRads = maxRotationAccelerationRads;
        }
        //apply the acceleration to the current rotation speed.
        //you'll want to multiply the acceleration by Time.deltaTime, 
        //because we're using Quaternion.RotateTowards to apply our acceleration and we're in Update() instead of FixedUpdate().
        rotationSpeedRads = rotationSpeedRads + accelerationRads * Time.deltaTime;

        //use Quaternion.LookRotation() to generate the quaternion representing the orientation which we would like to face
        //use Quaternion.RotateTowards with the time-step being the current rotational speed. 
        lookWhereYoureGoing = Quaternion.LookRotation(goalFacing, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookWhereYoureGoing, rotationSpeedRads);
    }
}
