using UnityEngine;
using System.Collections;

public class ScenarioUnit : MonoBehaviour {
	public GameObject[] prefabs;
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
		int idx = (int)Mathf.Round (Random.Range (0, prefabs.Length));
		GameObject go = (GameObject) Instantiate (prefabs[idx], new Vector3(x, Random.value, z), new Quaternion());
		go.transform.SetParent (this.transform, false);
		go.AddComponent<Rotater>();
		float size = Random.value * 0.7f;
		float gs = Random.value;
		go.transform.localScale = new Vector3 (size, size, size);
		Material material = go.GetComponentInChildren<Renderer>().material;
		material.color = new Color(gs, gs, gs);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
