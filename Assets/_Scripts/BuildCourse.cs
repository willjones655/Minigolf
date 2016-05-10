using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BuildCourse : MonoBehaviour {
	//	System
	Dictionary<string, GameObject> piecesByName;
	Dictionary<string, float> pieceProbability;
	float baseProbability = 1f;

	//	Plan Course


	//	Game Setup
	public int courseLength;
	public GameObject[] coursePiecePrefabs;

	public AnimationCurve animationCurve;

	//	Debugging
	public string[] setCourse;

	public void GenerateCourse(){
		Debug.Log("I'm RUNNING");
		//	Create Lookup table...aw yis
		piecesByName = new Dictionary<string, GameObject>();
		pieceProbability = new Dictionary<string, float>();

		//	Add course pieces to dictionary
		for(int i = 0; i < coursePiecePrefabs.Length; i++){
			piecesByName.Add(coursePiecePrefabs[i].name, coursePiecePrefabs[i]);
			pieceProbability.Add(coursePiecePrefabs[i].name, baseProbability);
		}
			
		List<string> plannedCourse = PlanCourse();

		MakeCourse(plannedCourse);
	}

	public List<string> PlanCourse(){
		//	Create course as list of strings
		List<string> coursePlan = new List<string>();

			//	Plan tee
		coursePlan.Add("Tee");
			//	Course pieces of <i> length
		for(int i = 0; i < 10; i++){
			string newPiece = SelectPiece(pieceProbability);

			if (newPiece == "Hole" || newPiece == "Tee"){
				i--;
				continue;
			}

			coursePlan.Add(newPiece);
		}
			//	Plan hole
		coursePlan.Add("Hole");

		//	return List<string>
		return coursePlan;
	}

	public void MakeCourse(List<string> plannedCourse) {

		Vector3 startPoint = Vector3.zero;
		Vector3 courseDirection = Vector3.zero;
		Transform prevPieceEndMarker;
		int i = 0;

		foreach(string pieceName in plannedCourse){
//			Debug.Log(pieceName + " is at " + courseDirection);

			i++;

			GameObject piece = Instantiate(piecesByName[pieceName], startPoint,Quaternion.Euler(courseDirection)) as GameObject;
			piece.tag = "CoursePiece";
			piece.name = i + " \t " + pieceName;
			prevPieceEndMarker = piece.transform.FindChild("Markers").transform.FindChild("End");

			//	Set direction for next piece to face
			courseDirection = courseDirection + prevPieceEndMarker.transform.localRotation.eulerAngles;
			startPoint = prevPieceEndMarker.transform.position;
		}

	}

	string SelectPiece(Dictionary<string, float> probCourse){
//		return setCourse[courseIndex];
//		return coursePiecePrefabs[Random.Range(0,coursePiecePrefabs.Length)].name;

		//	Turn dictionary into a list and sort from highest
		List<KeyValuePair<string, float>> probs = pieceProbability.ToList();
		probs.Sort((x, y) => x.Value.CompareTo(y.Value));

		float total = 0;

		//	Sum all prob weights
		foreach (KeyValuePair<string, float> elem in probs) {
			total += elem.Value;
		}

		//	Random value between 0 and total
		float randomPoint = Random.value * total;

		//	Using probs to find out which piece to pick
		for (int i= 0; i < probs.Count; i++) {
			if (randomPoint < probs[i].Value) {
				return probs[i].Key;
				ChangeProbability(probs.ToDictionary(x => x.Key, x => x.Value), probs[i].Key, 1f);
			}
			else {
				randomPoint -= probs[i].Value;
			}
		}

		//	If all else fails, return Hole
		return "Hole";
	}

	void ChangeProbability(Dictionary<string, float> probCourse, string pieceName, float probDifference){

		probCourse[pieceName] = probCourse[pieceName] - probDifference;
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
