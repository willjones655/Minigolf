using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//	Movement
	public float speed;
	public float turnSpeed;
	public GameObject ball;
	private GameController gc;

	//	Console
	private Rigidbody ballRb;
	private BallController ballController;
	private Transform club;
	public PowerBar powerBar;

	//	Hit
	private int hitPower;
	public static int maxPower = 2000;
	private float angle = 0f;
	private float angleDel = 5f;


	// Use this for initialization
	void Start () {
		ballController = ball.GetComponent<BallController>();
		//	Get Club
		club = gameObject.transform.GetChild(0);
		hitPower = 0;
		gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		//	Power from keyboard input
		if (!gc.youWin)
		{

			if (Input.GetKey(KeyCode.W)){
				hitPower += 10;
				powerBar.SetAmount(hitPower,maxPower);
				if(hitPower > maxPower) {
					hitPower = maxPower;
				}
				Debug.Log(hitPower);
			}

			//	If the ball is moving
			if(!ballController.CanHit()){
				changeColor(0f);
			}

			//	If the ball is stationary
			if(ballController.CanHit()){
				changeColor(1f);
			}

			if(Input.GetKey(KeyCode.A)) {
				angle += angleDel;
				gameObject.transform.RotateAround(ball.transform.position, Vector3.up, angleDel);
			}
			if(Input.GetKey(KeyCode.D)) {
				angle -= angleDel;
				gameObject.transform.RotateAround(ball.transform.position, Vector3.up, -angleDel);
			}
				
			//	Call Hit from Ball Controller
			if(Input.GetKeyUp(KeyCode.W)) {
				Vector3 direction = getPlayerDirection();
				ballController.Hit(direction, hitPower);
				hitPower = 0;

			}
		}
	}

	private Vector3 getPlayerDirection(){
		return gameObject.transform.forward;
	}

	private void changeColor(float newColorValue){
		// Save current club color
		Material[] mats = club.GetComponent<Renderer>().materials;
		//	Value between current .a and newColor Value

		foreach(Material mat in mats){
//			Color newColor = mat.color;
//			newColor.a = newColorValue;
//			mat.SetColor("_Color", newColor);

			Color newColor = mat.color;
			newColor.a = newColorValue;
			mat.SetColor("_Color", newColor);
		}
	}

}
