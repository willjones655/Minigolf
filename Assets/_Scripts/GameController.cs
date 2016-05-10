using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
		build.GenerateCourse();
		canvas.SetActive(true);
		winTextMesh.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (youWin){
			winTextMesh.text = winText;
		}

		if (Input.GetMouseButtonDown(0)){
			build.DestroyCourse();
			build.GenerateCourse();
		}
	}


}
