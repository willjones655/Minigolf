using UnityEngine;
using System.Collections;

public class ProbabilityCurve : MonoBehaviour {

	public float CurveWeightedRandom(AnimationCurve curve) {
		return curve.Evaluate(Random.value);
	}
}
