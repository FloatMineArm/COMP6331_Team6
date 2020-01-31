using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	[SerializeField]
	private Rigidbody playerBody;
	private Vector3 input;

	//screen wrap
	//Camera cam = Camera.main;
	//Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);
	private Renderer renderers;
	private bool isWrappingX = false;
	private bool isWrappingY = false;
	//screen wrap

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
		renderers = GetComponentInChildren<Renderer>();
	}

	private void FixedUpdate(){
		playerBody.velocity = input;

		ScreenWrap ();
	}
	
	// Update is called once per frame
	void Update () {
		input = new Vector3 (Input.GetAxisRaw ("Horizontal")*speed, playerBody.velocity.y, Input.GetAxisRaw ("Vertical")*speed);
		transform.LookAt(transform.position + new Vector3(input.x, 0 , input.z));
		//transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime, 0, Input.GetAxis ("Vertical") * Time.deltaTime);
		//transform.position += movement * Time.deltaTime * speed;
	}

	void ScreenWrap(){
		bool isVisible = CheckRenderers ();

		if(isVisible)
		{
			isWrappingX = false;
			isWrappingY = false;
			return;
		}

		if(isWrappingX && isWrappingY) {
			return;
		}

		var cam = Camera.main;
		var viewportPosition = cam.WorldToViewportPoint(transform.position);
		var newPosition = transform.position;

		if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
		{
			newPosition.x = -newPosition.x;

			isWrappingX = true;
		}

		if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
		{
			newPosition.y = -newPosition.y;

			isWrappingY = true;
		}

		transform.position = newPosition;
	}

	bool CheckRenderers(){
		foreach(Renderer renderer in renderers)
		{
			// If at least one render is visible, return true
			if(renderer.isVisible)
			{
				return true;
			}
		}

		// Otherwise, the object is invisible
		return false;
	}
}
