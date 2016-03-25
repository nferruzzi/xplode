using UnityEngine;
using System.Collections;

public class ScenarioUnit : MonoBehaviour {
	public GameObject prefab;
	public int width;
	public int depth;
	public float density;

	// Use this for initialization
	void Start () {
		for (int x = -width; x <= width; ++x) {
			for (int z = -depth; z <= depth; ++z) {
				if (Random.value < density) {
					Inst (x, z);
				}
			}
		}
	}

	void Inst (int x, int z) {
		GameObject go = (GameObject) Instantiate (prefab, new Vector3(x, Random.value * 2, z), new Quaternion());
		go.transform.SetParent (this.transform, false);
		float size = Random.value;
		float gs = Random.value;
		go.transform.localScale = new Vector3 (size, size, size);
		Material material = go.GetComponent<Renderer>().material;
		material.color = new Color(gs, gs, gs);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
