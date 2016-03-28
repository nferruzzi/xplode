using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float energy = 10.0f;
	Vector3 restart;

	void Start () {
		restart = transform.position;
	}

	void Respawn() {
		transform.position = restart;
		energy = 10;
		gameObject.SetActive (true);
	}

	void Die () {
		WeaponController wc = gameObject.GetComponent<WeaponController> ();
		wc.FireUp ();
		Invoke ("Respawn", 3.0f);
		gameObject.SetActive (false);
	}

	void Update () {
	}

	void OnCollisionEnter(Collision collision) {
		Proiettile pro = collision.gameObject.GetComponentInChildren<Proiettile> ();
		if (pro != null) {
			energy -= pro.damage;

			foreach (ContactPoint contact in collision.contacts) {
				pro.ShowExplosionAt (contact.point, contact.normal);
			}

			if (energy <= 0.0f) {
				Die ();
			}
		} else {
			// Insta death
			Die ();
		}
	}
}
