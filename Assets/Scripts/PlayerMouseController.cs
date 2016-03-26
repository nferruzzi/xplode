using UnityEngine;
using System.Collections;

public class PlayerMouseController : MonoBehaviour {

	Vector3 dragStart;
	WeaponController weaponController;
	public float dragSpeed = 0.03f;

	// Use this for initialization
	void Start () {
		weaponController = gameObject.GetComponent<WeaponController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			dragStart = Input.mousePosition;
		}

		if (Input.GetMouseButton (0)) {
			Vector3 d = Input.mousePosition - dragStart;
			transform.position += new Vector3 (d.x, 0, d.y) * dragSpeed;
			dragStart = Input.mousePosition;
			weaponController.FireDown (gameObject, Vector3.forward * 1.5f);
		} else {
			weaponController.FireUp ();
		}
	}
}
