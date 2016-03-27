using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SpawnableEnemy {
	public GameObject enemey;
	public int minPerSpawn = 1;
	public int maxPerSpawn = 2;
	public float delay = 1.0f;
}

public class LevelRandomGenerator : MonoBehaviour
{
	public float timeStart = 2.0f;
	public float timeEnd = 100.0f;

	public float spawningFrequency = 1.0f;
	public List<SpawnableEnemy> spawnableEnemies;


	void Start () {	
		StartGeneration ();
	}

	void StartGeneration () {
		InvokeRepeating ("Spawn", timeStart, spawningFrequency);
	}

	void Spawn () {
		if (spawnableEnemies.Count == 0)
			return;
		
		int index = Random.Range (0, spawnableEnemies.Count);
		SpawnableEnemy se = spawnableEnemies [index];

		int n = Random.Range (se.minPerSpawn, se.maxPerSpawn);
		while (n > 0) {
			StartCoroutine (SpawnAfter (se.enemey, Random.value * se.delay));
			--n;
		}
	}

	IEnumerator SpawnAfter(GameObject go, float delay) {
		yield return new WaitForSeconds(delay);
		Instantiate (go);
	}
	
	void Update () {
	}
}

