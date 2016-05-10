using UnityEngine;
using System.Collections;

public class PowerBar : MonoBehaviour {
	//	System
	private RectTransform rt;
	private float width;

	// Use this for initialization
	void Start () {
		rt = gameObject.GetComponent<RectTransform>();
		width = rt.rect.width;
		Debug.Log(width);
		rt.sizeDelta= Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetAmount (int power, int max){
		rt.sizeDelta= new Vector2(((float)power/(float)max) * width, 24);
//		Debug.Log("Power / Max = " + power/max + " Power " + power + " Max " + max);
	}
}
