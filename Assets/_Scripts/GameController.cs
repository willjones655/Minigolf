using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Course;

public class GameController : MonoBehaviour {

	//	Win Text
	public GameObject canvas;
	public Text winTextMesh;
	public bool youWin;
	public string winText;

	BuildCourse build;

	// Use this for initialization
	void Start () {
		build = gameObject.GetComponent<BuildCourse>();
//		build.GenerateCourse();
		build.LoadCourse("shortest");
		canvas.SetActive(true);
		winTextMesh.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (youWin){
			winTextMesh.text = winText;
		}

		if (Input.GetKey (KeyCode.S)) {
			// TODO: Prompt for name
			build.StoreCourse("test");
			// TODO: Show success/error message
		}

		if (Input.GetMouseButtonDown(0)){
			build.DestroyCourse();
			build.GenerateCourse();
		}
	}


}
