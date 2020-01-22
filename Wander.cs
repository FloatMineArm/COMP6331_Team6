using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour {

   // public GameObject prefabSquare;
    float wanderCircleCenterOffset = 200.0f;
    float wanderCircleRadius = 100.0f;
    float maxWanderVariance = 0.0f;

    
    float speed = 20.0f;
    float distanceFromTarget;

    public Vector3 currentRandomPoint;
    public Vector3 moveDirection;


    void start(){
        //InvokeRepeating("WanderCirclePoint", 3f, 0.1f);
    }

    void FixedUpdate()
    {
        
        Vector3 currentRandomPoint = WanderCirclePoint();
        Vector3 moveDirection = (currentRandomPoint - transform.position).normalized;
        GetComponent<Rigidbody>().velocity = (moveDirection * speed);
    }

    Vector3 WanderCirclePoint()
    {

        //For the wandering behaviour, you can generate a random point and seek to it
        //BUT
        //that's boring and looks bad.

        //Instead, if you want to get wandering behaviour that looks like the examples from class,
        //you should pick a random point along a circle in front of the GameObject.

        //There is a LOT of tuning of numbers to get this to look right, but the end result should be
        //an object that wanders more gradually toward points in front of it.
        //Helpful things:
        //1.(sin^2 + cos^2 = 1)
        //2.Vector3.ProjectOnPlane(Vector3 forward, Vector3 up)

        Vector3 wanderCircleCenter = transform.position + 
        (Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * wanderCircleCenterOffset);

        Vector3 wanderCirclePoint = wanderCircleRadius * (new Vector3(Mathf.Cos(Random.Range(maxWanderVariance, Mathf.PI - maxWanderVariance)),
                                                                      0f,
                                                                      Mathf.Sin(Random.Range(maxWanderVariance, Mathf.PI - maxWanderVariance))
                                                                      )
                                                         );
        //currentRandomPoint = wanderCirclePoint + wanderCircleCenter;
        //moveDirection = (currentRandomPoint - transform.position).normalized;
        //GetComponent<Rigidbody>().velocity = (moveDirection * speed);

        return wanderCirclePoint+wanderCircleCenter; //<--you should return whichever point you generate here.
    }
	
}
