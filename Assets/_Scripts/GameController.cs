using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//	System
	public GameObject canvas;
	public Text winTextMesh;
	public bool youWin;
	public string winText;

	// Use this for initialization
	void Start () {
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
