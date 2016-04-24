using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//	Movement
	public float speed;
	public float turnSpeed;
	public GameObject ball;

	//	Console
	private Rigidbody ballRb;
	private BallController ballController;

	//	Hit
	private int hitPower;
	public static int maxPower = 2000;
	private float angle;
	private float angleDel = 5f;


	// Use this for initialization
	void Start () {
		ballController = ball.GetComponent<BallController>();

		hitPower = 0;

//		if (ball != null){
//			Debug.Log ("Found the Ball");
//			Debug.Log (ball.name);
//		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//	Power from keyboard input
		if (Input.GetKey(KeyCode.W)){
			hitPower += 10;

			if(hitPower > maxPower) {
				hitPower = maxPower;
			}

			Debug.Log(hitPower);
		}

		//	Display ring when CanHit
		if(ballController.CanHit()) {
			
		}

		if(Input.GetKey(KeyCode.A)) {
//			angle += angleDel;
			gameObject.transform.RotateAround(ball.transform.position, Vector3.up, angleDel);

		}
		if(Input.GetKey(KeyCode.D)) {
//			angle -= angleDel;
			gameObject.transform.RotateAround(ball.transform.position, Vector3.up, -angleDel);

		}


		//	Call Hit from Ball Controller
		if(Input.GetKeyUp(KeyCode.W)) {
			Vector3 direction = new Vector3(0,0,1);

			ballController.Hit(direction, hitPower);
			hitPower = 0;
		}
	}
}
