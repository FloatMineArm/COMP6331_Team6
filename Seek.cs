using UnityEngine;
using System.Collections;

public class Seek : MonoBehaviour {

    public GameObject target;
    float speed = 20.0f;
    float distanceFromTarget;

    void Update()
    {
        //Seek should more TOWARD the target object.
        GetComponent<Rigidbody>().velocity = (target.transform.position - transform.position).normalized * speed;
    }
}
