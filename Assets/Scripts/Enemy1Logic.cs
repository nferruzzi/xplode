using UnityEngine;
using System.Collections;

public class Enemy1Logic : MonoBehaviour {

	public GameObject proiettile;

	// Use this for initialization
	void Start () {
		transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
	}

	void Spara() {
		GameObject go = (GameObject)Instantiate (proiettile, transform.position + (transform.forward * 1.0f), new Quaternion());
		Rigidbody rb = go.GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward, ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update () {
		if (Random.value < 0.01) {
			Spara ();
		}	
	}
}
