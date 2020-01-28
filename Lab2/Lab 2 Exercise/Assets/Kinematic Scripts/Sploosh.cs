using UnityEngine;
using System.Collections;

public class Sploosh : MonoBehaviour {

    public AudioSource spluush;
    Rigidbody[] bodyParts;
	// Use this for initialization
	void Start () {
        bodyParts = this.transform.parent.GetComponentsInChildren<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, -1.0f), ForceMode.Impulse);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RiverCol")
        {
            spluush.Play();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            foreach (Rigidbody bodyPart in bodyParts)
            {
                bodyPart.detectCollisions = false;
            }
        }
    }
}
