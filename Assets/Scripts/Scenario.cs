using UnityEngine;
using System.Collections;


public class Scenario : MonoBehaviour {
	public GameObject scenario;
	public Vector3 speed;

	private GameObject prev;
	private GameObject current;
	private GameObject next;

	private int unit_depth;

	// Use this for initialization
	void Start () {
		ScenarioUnit g = scenario.GetComponent<ScenarioUnit> ();
		Scroller s = scenario.GetComponent<Scroller> ();
		s.speed = speed;
		unit_depth = 2 * g.depth + 1;
		Physics.IgnoreLayerCollision (8, 8);
		prev = Inst (new Vector3(0, 0, -unit_depth));
		current = Inst (new Vector3(0, 0, 0));
		next = Inst (new Vector3(0, 0, unit_depth));
	}

	GameObject Inst (Vector3 position) {
		GameObject go = (GameObject)Instantiate (scenario, position, new Quaternion ());
		go.transform.SetParent (this.transform, false);
		return go;
	}
	
	// Update is called once per frame
	void Update () {
		if (prev.transform.position.z <  -unit_depth) {
			GameObject tmp = prev;
			prev = current;
			current = next;
			next = Inst (new Vector3 (0, 0, current.transform.position.z + unit_depth));
			Destroy (tmp);
		}
	}
}
