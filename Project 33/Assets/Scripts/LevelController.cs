using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public GameObject background;
    public GameObject scenery;
    public GameObject ground;

    public float backgroundMoveSpeed = 1;
    public float sceneryMoveSpeed = 2;
    public float groundMoveSpeed = 3;

    Vector3 startPosition;
    Vector3 endPosition;
    float speed = 10.0f;

    

    // Use this for initialization
    void Start () {
	
	}

	void Update () {
        transform.position = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
    }
}