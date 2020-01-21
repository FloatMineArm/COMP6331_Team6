using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	[SerializeField]
	private Rigidbody playerBody;
	private Vector3 input;

	public float speed;

	//===for enemy===
	public float fieldOfView = 110f;
	public bool playerInSight = false;
	private GameObject player;
	//===for enemy===


	// Use this for initialization
	void Start () {
		playerBody = GetComponent<Rigidbody>();
		//float speed = 1f;

	}
	
	// Update is called once per frame
	void Update () {
		input = new Vector3 (Input.GetAxisRaw ("Horizontal")*speed, playerBody.velocity.y, Input.GetAxisRaw ("Vertical")*speed);
		transform.LookAt(transform.position + new Vector3(input.x, 0 , input.z));
		//transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime, 0, Input.GetAxis ("Vertical") * Time.deltaTime);
		//transform.position += movement * Time.deltaTime * speed;
	}

	private void FixedUpdate(){
		playerBody.velocity = input;
	}
}
