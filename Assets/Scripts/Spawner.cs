using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float gameLevel = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos() {
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
			Vector3 bl = bottomLeftRay.GetPoint(bottomLeftDistance);

			if (pl.Raycast (topLeftRay, out topLeftDistance)) {
				Vector3 tl = topLeftRay.GetPoint(topLeftDistance);

				if (pl.Raycast (bottomRightRay, out bottomRightDistance)) {
					Vector3 br = bottomRightRay.GetPoint(bottomRightDistance);

					if (pl.Raycast (topRightRay, out topRightDistance)) {
						Vector3 tr = topRightRay.GetPoint(topRightDistance);

						Gizmos.color = Color.green;
						Gizmos.DrawLine (bl, br);
						Gizmos.DrawLine (br, tr);
						Gizmos.DrawLine (tr, tl);
						Gizmos.DrawLine (tl, bl);
					}
				}
			}
		}
	}
}
