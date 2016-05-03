using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//	Win Text
	public GameObject canvas;
	public Text winTextMesh;
	public bool youWin;
	public string winText;

	// Use this for initialization
	void Start () {
		BuildCourse build = gameObject.GetComponent<BuildCourse>();
		build.MakeCourse();
		canvas.SetActive(true);
		winTextMesh.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (youWin){
			winTextMesh.text = winText;
		}
	}


}
