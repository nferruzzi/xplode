using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IWeaponInterface
{
	void FireDown (GameObject parent, Vector3 offset);
	void FireUp ();
}

public interface IProjectileInterface
{
	float damage {
		get;
		set;
	}

	GameObject gameObject {
		get;
	}

	void ShowExplosionAt (Vector3 point, Vector3 normal);
}

public class WeaponController : MonoBehaviour {

	List<IWeaponInterface> currentWeapons;
	public GameObject mainGun;

	// Use this for initialization
	void Start () {	
		currentWeapons = new List<IWeaponInterface>();
		currentWeapons.Add (GetWeaponInterfaceFromGameObject(mainGun));
	}

	IWeaponInterface GetWeaponInterfaceFromGameObject(GameObject go) {
		return go.GetComponentInChildren<IWeaponInterface> ();
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void FireDown (GameObject parent, Vector3 offset) {
		foreach (var weapon in currentWeapons) {
			weapon.FireDown (parent, offset);
		}
	}

	public void FireUp() {
		foreach (var weapon in currentWeapons) {
			weapon.FireUp ();
		}
	}
}
