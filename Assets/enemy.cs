using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	private float t;
	public int startY = 3;
	public int startX = -10;
	public int startZ = -10;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (startX, startY, startZ);
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		t = Time.time;
		if (t < 2) {
			transform.position -= ( new Vector3(0, 0, 0.3f) + Vector3.left) * Time.deltaTime * 5f;
		}

		if (t > 4) {
			transform.position -= (new Vector3(0, 0, -0.3f) + Vector3.left) * Time.deltaTime * 5f;
		}

		if (t > 8) {
			Destroy(gameObject);
		}

	}
}
