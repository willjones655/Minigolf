using UnityEngine;
using System.Collections;

public class BuildCourse : MonoBehaviour {
	//	Game Setup
	public int numberOfPieces;
	public GameObject tee;
	public GameObject hole;
	public GameObject[] coursePieces;

	private Transform prevPieceEndMarker;

	public void MakeCourse() {

		//	Spawn Tee
		GameObject teeTrans = Instantiate(tee,Vector3.zero,Quaternion.identity) as GameObject;
		teeTrans.tag = "Tee";

		//	Save previous piece End Marker transform
		prevPieceEndMarker = tee.transform.FindChild("Markers").transform.FindChild("End");
		Debug.Log(prevPieceEndMarker.name);

		//	Spawn tiles
		for (int i = 0; i < numberOfPieces; i++){
			Vector3 startPoint = prevPieceEndMarker.transform.position;
			Vector3	startRot = prevPieceEndMarker.transform.localRotation.eulerAngles;
			GameObject piece = Instantiate(coursePieces[i], startPoint,Quaternion.Euler(startRot)) as GameObject;
			piece.name = "Piece " + (i + 1);
			prevPieceEndMarker = piece.transform.FindChild("Markers").transform.FindChild("End");
		}

		//	Spawn Hole
		GameObject holeTrans = Instantiate(hole,prevPieceEndMarker.transform.position,Quaternion.identity) as GameObject;
		holeTrans.tag = "Hole";

	}
}
