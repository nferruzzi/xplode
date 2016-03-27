using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Spawner : MonoBehaviour {

	public float gameYLevel = 5.0f;
	public float sideSubdivision = 5.0f;
	public float spawnPointMargin = 4.0f;
	public List<Vector3> spawnLocationsTop;
	public List<Vector3> spawnLocationsLeft;
	public List<Vector3> spawnLocationsRight;
	public Vector3 nBoundaryUp, nBoundaryLef, nBoundaryRight;

	Vector3 bl, br, tl, tr;

	public static Spawner GetInstance() {
		GameObject go = GameObject.FindGameObjectWithTag ("Level");
		return go.GetComponentInChildren<Spawner> ();
	}

	void Start () {
		CalcAll ();
	}
		
	void CalcAll() {
		CalcFrustumPlane (gameYLevel, ref bl, ref br, ref tr, ref tl);
		CalcSpawningPoints ();
	}

	void CalcFrustumPlane (float yLevel, ref Vector3 lbl, ref Vector3 lbr, ref Vector3 ltr, ref Vector3 ltl) {
		Camera ca = Camera.main;

		Ray bottomLeftRay = ca.ViewportPointToRay(new Vector3(0, 0, 0));
		Ray topLeftRay = ca.ViewportPointToRay(new Vector3(0, 1, 0));
		Ray topRightRay = ca.ViewportPointToRay(new Vector3(1, 1, 0));
		Ray bottomRightRay = ca.ViewportPointToRay(new Vector3(1, 0, 0));

		Plane pl = new Plane (Vector3.up, new Vector3 (0, yLevel, 0));

		float bottomLeftDistance;
		float topLeftDistance;
		float bottomRightDistance;
		float topRightDistance;

		if (pl.Raycast (bottomLeftRay, out bottomLeftDistance)) {
			lbl = bottomLeftRay.GetPoint(bottomLeftDistance);

			if (pl.Raycast (topLeftRay, out topLeftDistance)) {
				ltl = topLeftRay.GetPoint(topLeftDistance);

				if (pl.Raycast (bottomRightRay, out bottomRightDistance)) {
					lbr = bottomRightRay.GetPoint(bottomRightDistance);

					if (pl.Raycast (topRightRay, out topRightDistance)) {
						ltr = topRightRay.GetPoint(topRightDistance);
					}
				}
			}
		}
	}

	void CalcSpawningPoints() {
		float sud = 1.0f / sideSubdivision;

		Vector3 up = (tr + tl) * 0.5f;
		Vector3 left = (tl + bl) * 0.5f;
		Vector3 right = (tr + br) * 0.5f;
		Vector3 center = (tr + tl + br + bl) * 0.25f;
		nBoundaryUp = (up - center).normalized;
		nBoundaryLef = (left - center).normalized;
		nBoundaryRight = (right - center).normalized;

		spawnLocationsTop = new List<Vector3> ();
		for (float t = sud; t < 1.0f; t += sud) {
			Vector3 point = Vector3.Lerp (tl, tr, t);
			point += nBoundaryUp * spawnPointMargin;
			spawnLocationsTop.Add (point);
		}

		spawnLocationsLeft = new List<Vector3> ();
		for (float t = sud; t <= 1.0f; t += sud) {
			Vector3 point = Vector3.Lerp (tl, bl, t);
			point += nBoundaryLef * spawnPointMargin;
			spawnLocationsLeft.Add (point);
		}

		spawnLocationsRight = new List<Vector3> ();
		for (float t = sud; t <= 1.0f; t += sud) {
			Vector3 point = Vector3.Lerp (tr, br, t);
			point += nBoundaryRight * spawnPointMargin;
			spawnLocationsRight.Add (point);
		}
	}

	void Update () {	
	}

	void OnGUI() {
		CalcAll ();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawLine (bl, br);
		Gizmos.DrawLine (br, tr);
		Gizmos.DrawLine (tr, tl);
		Gizmos.DrawLine (tl, bl);

		Gizmos.color = Color.red;
		foreach (Vector3 point in spawnLocationsTop) {
			Gizmos.DrawWireSphere (point, 0.2f);
		}
		foreach (Vector3 point in spawnLocationsLeft) {
			Gizmos.DrawWireSphere (point, 0.2f);
		}
		foreach (Vector3 point in spawnLocationsRight) {
			Gizmos.DrawWireSphere (point, 0.2f);
		}
	}

}
