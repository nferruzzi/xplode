using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float energy = 10.0f;

	void Start () {
	}
	
	void Update () {
	}

	void OnCollisionEnter(Collision collision) {
		Proiettile pro = collision.gameObject.GetComponentInChildren<Proiettile> ();
		energy -= pro.damage;

		foreach (ContactPoint contact in collision.contacts) {
			pro.ShowExplosionAt (contact.point, contact.normal);
		}

		if (energy <= 0.0f) {
			Destroy (this.gameObject);
		}	
	}
}
