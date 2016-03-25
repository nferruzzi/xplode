using UnityEngine;
using System.Collections;

public class PlayerMouseController : MonoBehaviour {

	Vector3 dragStart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			dragStart = Input.mousePosition;
		}

		if (Input.GetMouseButton (0)) {
			Vector3 d = Input.mousePosition - dragStart;
			transform.position += new Vector3 (d.x, 0, d.y) * 0.01f;
			dragStart = Input.mousePosition;
		}
	}
}
