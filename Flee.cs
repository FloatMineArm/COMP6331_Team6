using UnityEngine;
using System.Collections;

public class Flee : MonoBehaviour {

    public GameObject target;
    float speed = 15.0f;
    float distanceFromTarget;

    void Update()
    {
     //flee should move AWAY from the target object.
     GetComponent<Rigidbody>().velocity = -(target.transform.position - transform.position).normalized * speed;
    }
}
