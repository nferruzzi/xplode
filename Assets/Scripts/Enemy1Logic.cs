using UnityEngine;
using System.Collections;

public class Enemy1Logic : MonoBehaviour {

	public GameObject proiettile;

	private float firingInterval;
	private float tLastFire;

	// Use this for initialization
	void Start () {
		tLastFire = Time.time;

		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		// Rotate the enemy towards the player
		transform.LookAt(player.transform);
	}

	void Spara() {
		GameObject b1 = (GameObject)Instantiate (proiettile, transform.position + (transform.forward + transform.right), new Quaternion());
		GameObject b2 = (GameObject)Instantiate (proiettile, transform.position + (transform.forward - transform.right), new Quaternion());
		Rigidbody rb1 = b1.GetComponent<Rigidbody> ();
		Rigidbody rb2 = b2.GetComponent<Rigidbody> ();


		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Vector3 heading1 = player.transform.position - b1.transform.position;
		Vector3 heading2 = player.transform.position - b2.transform.position;
		rb1.AddForce (heading1, ForceMode.Impulse);
		rb2.AddForce (heading2, ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update () {
		if ((Time.time - tLastFire) > firingInterval) {
			Spara ();

			tLastFire = Time.time;
			firingInterval = 0.5F + Random.value * 3;
		}	
	}
}
