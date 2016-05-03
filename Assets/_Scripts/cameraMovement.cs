using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
	private Transform curBallTrans;

	// Use this for initialization
	void Start () {
		curBallTrans = GameObject.FindGameObjectWithTag("CurrentBall").transform;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = curBallTrans.position;
	}
}
