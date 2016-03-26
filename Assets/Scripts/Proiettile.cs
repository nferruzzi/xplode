using UnityEngine;
using System.Collections;

public class Proiettile : MonoBehaviour, IProjectileInterface {

	float projectileDamage;

	void Start () {
		Destroy (gameObject, 3.0f);
	}
	
	void Update () {	
	}

	public float damage {
		get {
			return projectileDamage;
		}

		set {
			projectileDamage = value;
		}
	}

	public void ShowExplosionAt (Vector3 point, Vector3 normal) {
	}

	void OnCollisionEnter(Collision collision) {
		Destroy (gameObject);
	}
		
}
