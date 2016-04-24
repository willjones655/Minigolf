using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	private Rigidbody rb;
	private Vector3 dir;

	// Use this for initialization
	void Start () {
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
}
