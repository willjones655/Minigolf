using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	AnimationCurve buildCurve;

	// Use this for initialization
	void Start () {
		//buildCurve = gameObject.GetComponent<BuildCourse>().animationCurve;

////			** WORKING ** Load all course pieces from Resources folder
//		Object[] allCoursePieces = Resources.LoadAll("Pieces");
//		foreach(Object piece in allCoursePieces){
//			GameObject corner = Instantiate(piece,Vector3.zero, Quaternion.identity) as GameObject;
//		}

		//	** WIP ** Change probablility curve during play
		//buildCurve.AddKey(0.2f, 0.5f);

	}
}
