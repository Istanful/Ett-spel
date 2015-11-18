using UnityEngine;
using System.Collections;

public class SpawnIfNotSpawned : MonoBehaviour {
    public GameObject objectToSpawn;
	void Start () {
	    if (!GameObject.Find(objectToSpawn.name))
        {
            Instantiate(objectToSpawn).name = "GameController";
        }
	}
}
