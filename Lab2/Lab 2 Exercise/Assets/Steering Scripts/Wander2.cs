using UnityEngine;
using System.Collections;

public class Wander2 : MonoBehaviour {

   // public GameObject prefabSquare;
    float wanderCircleCenterOffset = 200.0f;
    float wanderCircleRadius = 100.0f;
    float maxWanderVariance = 0.0f;

    
    float speed = 20.0f;
    float distanceFromTarget;

    void Update()
    {
        
        Vector3 currentRandomPoint = WanderCirclePoint();
        Vector3 moveDirection = (currentRandomPoint - transform.position).normalized;
        //GameObject clonePoint = (GameObject)Instantiate(prefabSquare, currentRandomPoint, Quaternion.identity);
        //Destroy(clonePoint, 2.0f);
        GetComponent<Rigidbody>().velocity = (moveDirection * speed);
    }

    Vector3 WanderCirclePoint()
    {
        Vector3 wanderCircleCenter = transform.position + (Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * wanderCircleCenterOffset);
        Vector3 wanderCirclePoint = wanderCircleRadius*(new Vector3(Mathf.Cos(Random.Range(maxWanderVariance, Mathf.PI - maxWanderVariance)),
                                                0.0f,
                                                Mathf.Sin(Random.Range(maxWanderVariance, Mathf.PI- maxWanderVariance))));
       
        return (wanderCirclePoint+wanderCircleCenter);
    }
	
}
