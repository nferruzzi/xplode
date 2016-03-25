using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour {
	private float angle;
	// Use this for initialization
	void Start () {
		angle = Random.Range (-60, 60);
		float initialAngle = Random.Range (0, 360);
		transform.Rotate (new Vector3 (initialAngle, initialAngle, initialAngle));
	}
	
	// Update is called once per frame
	void Update () {
		float x = angle * Time.deltaTime;
		transform.Rotate (new Vector3(x, x, x));
	}
}
