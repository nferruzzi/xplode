using UnityEngine;
using System.Collections;

public class WeaponGun : MonoBehaviour, IWeaponInterface {

	public GameObject proiettile;
	public int totalBullets = -1;
	public int bulletsPerFire = 1;
	public float sideSpacing = 0.5f;
	public float velocity = 5.0f;
	public float fireRateSec = 3.0f;
	public float damage = 1.0f;

	GameObject parent;
	Vector3 offset;
	bool firing;

	// Use this for initialization
	void Start () {
		firing = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Fire () {
		// Space the bullets 
		for (int i = 0; i < bulletsPerFire; ++i) {
			Vector3 pos = parent.transform.position + offset;
			pos += parent.transform.right * (i - (float)(bulletsPerFire -1) / 2.0f) * sideSpacing;

			GameObject p = Instantiate (proiettile, pos, Quaternion.identity) as GameObject;
			IProjectileInterface pi = p.GetComponent<IProjectileInterface> ();
			pi.damage = damage;

			Rigidbody r = p.GetComponent<Rigidbody> ();
			r.velocity = transform.forward * velocity;
		}
	}

	public void FireDown(GameObject parent, Vector3 offset) {
		if (!firing) {
			this.parent = parent;
			this.offset = offset;
			firing = true;
			InvokeRepeating ("Fire", 0.0f, 1.0f / fireRateSec);
		}
	}

	public void FireUp() {
		CancelInvoke ("Fire");
		firing = false;
	}		
}
