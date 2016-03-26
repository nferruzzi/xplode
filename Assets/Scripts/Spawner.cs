using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Spawner : MonoBehaviour {

	public float gameLevel = 5.0f;
	public float sideSubdivision = 5.0f;
	Vector3 bl, br, tl, tr;

	void Start () {
		CalcFrustumPlane ();
	}

	void CalcFrustumPlane () {
		Camera ca = Camera.main;

		Ray bottomLeftRay = ca.ViewportPointToRay(new Vector3(0, 0, 0));
		Ray topLeftRay = ca.ViewportPointToRay(new Vector3(0, 1, 0));
		Ray topRightRay = ca.ViewportPointToRay(new Vector3(1, 1, 0));
		Ray bottomRightRay = ca.ViewportPointToRay(new Vector3(1, 0, 0));

		Plane pl = new Plane (Vector3.up, new Vector3 (0, gameLevel, 0));

		float bottomLeftDistance;
		float topLeftDistance;
		float bottomRightDistance;
		float topRightDistance;

		if (pl.Raycast (bottomLeftRay, out bottomLeftDistance)) {
			bl = bottomLeftRay.GetPoint(bottomLeftDistance);

			if (pl.Raycast (topLeftRay, out topLeftDistance)) {
				tl = topLeftRay.GetPoint(topLeftDistance);

				if (pl.Raycast (bottomRightRay, out bottomRightDistance)) {
					br = bottomRightRay.GetPoint(bottomRightDistance);

					if (pl.Raycast (topRightRay, out topRightDistance)) {
						tr = topRightRay.GetPoint(topRightDistance);
					}
				}
			}
		}
	}

	void Update () {	
	}

	void OnGUI() {
		CalcFrustumPlane ();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawLine (bl, br);
		Gizmos.DrawLine (br, tr);
		Gizmos.DrawLine (tr, tl);
		Gizmos.DrawLine (tl, bl);
	}

}
