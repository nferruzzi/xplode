using UnityEngine;
using System.Collections;

public class Enemy1Logic : MonoBehaviour {

	public GameObject proiettile;

	private float firingInterval;
	private float tLastFire;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		tLastFire = Time.time;
		rb = GetComponent<Rigidbody>();
	}

	void accelera(Vector3 direction, float v) {
		rb.AddForce (direction * v);
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

		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		// Rotate the enemy towards the player
		// TODO: give it a max angular velocity
		transform.LookAt(player.transform);

		if (Time.time < 2) {
			accelera (transform.forward, 2);
		} else if (Time.time > 2 & Time.time < 4) {
			accelera (transform.forward, -2);
		} else if (Time.time > 6) {
			accelera (transform.right, 1);
		} else if (Time.time > 10) {
			Destroy (this.gameObject);
		}

		if ((Time.time - tLastFire) > firingInterval) {
			Spara ();

			tLastFire = Time.time;
			firingInterval = 0.5F + Random.value * 3;
		}	
	}
}
