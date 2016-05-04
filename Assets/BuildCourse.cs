using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildCourse : MonoBehaviour {
	//	Game Setup
	public int courseLength;
	public GameObject tee;
	public GameObject hole;
	public GameObject[] coursePiecePrefabs;

	public AnimationCurve animationCurve;

	private Transform prevPieceEndMarker;
	private Vector3 courseDirection;
	private ProbabilityCurve probCurve;

	//	Debugging
	public string[] setCourse;

	void Start(){
		probCurve = gameObject.GetComponent<ProbabilityCurve>();
	}

	public void MakeCourse() {
		//	Create Lookup table...aw yis
		Dictionary<string, GameObject> piecesByName = new Dictionary<string, GameObject>();

		//	Add course pieces to dictionary
		for(int i = 0; i < coursePiecePrefabs.Length; i++){
			piecesByName.Add(coursePiecePrefabs[i].name, coursePiecePrefabs[i]);
		}

		//	Spawn Tee
		GameObject teeTrans = Instantiate(tee,Vector3.zero,Quaternion.identity) as GameObject;
		teeTrans.tag = "Tee";

		//	Save previous piece End Marker transform
		prevPieceEndMarker = tee.transform.FindChild("Markers").transform.FindChild("End");
//		Vector3	startRot = prevPieceEndMarker.transform.localRotation.eulerAngles;

//		Debug.Log(prevPieceEndMarker.name);

		//	Spawn tiles

		string pieceName;
//		courseLength = setCourse.Length;
		courseDirection = Vector3.zero;

		for (int i = 0; i < courseLength; i++){
			int pieceIndex = Mathf.RoundToInt(animationCurve.Evaluate(Random.value) * (coursePiecePrefabs.Length-1));
			Debug.Log(pieceIndex);
			pieceName = SelectPiece(i , pieceIndex);

			Vector3 startPoint = prevPieceEndMarker.transform.position;
			Debug.Log(pieceName + " is at " + courseDirection);

			GameObject piece = Instantiate(piecesByName[pieceName], startPoint,Quaternion.Euler(courseDirection)) as GameObject;
			piece.tag = "CoursePiece";
			prevPieceEndMarker = piece.transform.FindChild("Markers").transform.FindChild("End");

			//	Set direction for next piece to face
			courseDirection = courseDirection + prevPieceEndMarker.transform.localRotation.eulerAngles;

		}

		//	Spawn Hole
		GameObject holeTrans = Instantiate(hole,prevPieceEndMarker.transform.position,Quaternion.Euler(courseDirection)) as GameObject;
		holeTrans.tag = "Hole";
	}

	string SelectPiece(int courseIndex, int pieceIndex){
//		return setCourse[courseIndex];
//		return coursePiecePrefabs[Random.Range(0,coursePiecePrefabs.Length)].name;		

		return coursePiecePrefabs[pieceIndex].name;
	}

	public void DestroyCourse(){
		GameObject[] objs = GameObject.FindGameObjectsWithTag("CoursePiece");
		foreach(GameObject obj in objs){
			Destroy(obj);
		}
		Destroy(GameObject.FindGameObjectWithTag("Hole"));
		Destroy(GameObject.FindGameObjectWithTag("Tee"));

	}

}
