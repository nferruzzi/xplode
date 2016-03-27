using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {

	public float energy = 10.0f;
	Spawner spawner;

	void Start () {
		spawner = Spawner.GetInstance ();
		int index = Random.Range (0, spawner.spawnLocationsTop.Count);
		transform.position = spawner.spawnLocationsTop [index];
		transform.rotation = Quaternion.LookRotation(-spawner.nBoundaryUp, Vector3.up);
		Destroy (this.gameObject, 5.0f);
	}
	
	void Update () {	
		transform.position += -spawner.nBoundaryUp * Time.deltaTime * 5.0f;
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
