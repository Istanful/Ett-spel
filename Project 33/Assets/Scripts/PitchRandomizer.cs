using UnityEngine;
using System.Collections;

public class PitchRandomizer : MonoBehaviour {
    public float minPitch = 0.85f;
    public float maxPitch = 1.15f;

    void Start () {
        GetComponent<AudioSource>().pitch = Random.Range(minPitch, maxPitch);
	}
}