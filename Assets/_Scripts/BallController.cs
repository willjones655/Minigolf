using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	private Rigidbody rb;
	private Vector3 dir;

	GameController gc;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit(Vector3 direction, float power) {
		if(!CanHit()) {
			return;
		}

		rb.AddForce(direction.normalized * power);
	}

	public bool CanHit(){
		return rb.IsSleeping();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "WinTrigger"){
			if (gc != null){
				gc.youWin = true;
				Debug.Log(gc.youWin);

			}
		}
	}
}
