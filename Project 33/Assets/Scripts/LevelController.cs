using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    [Header("Enviroment objects.")]
    public GameObject background;
    public GameObject scenery;
    public GameObject ground;

    [Header("Enviroment scrolling speeds.")]
    public float backgroundScrollingSpeed = .1f;
    public float sceneryScrollingSpeed = .2f;
    public float groundScrollingSpeed = .3f;

    [Header("Enviroment start & end positions.")]
    public Vector3 backgroundStartPos;
    public Vector3 backgroundEndPos;

    public Vector3 sceneryStartPos;
    public Vector3 sceneryEndPos;

    public Vector3 groundStartPos;
    public Vector3 groundEndPos;
    
    void Start () {
        
    }

	void FixedUpdate () {
        background.transform.position = Vector3.Lerp(backgroundStartPos, backgroundEndPos, backgroundScrollingSpeed * Time.deltaTime);
        scenery.transform.position = Vector3.Lerp(sceneryStartPos, sceneryEndPos, sceneryScrollingSpeed * Time.deltaTime);
        ground.transform.position = Vector3.Lerp(groundStartPos, groundEndPos, groundScrollingSpeed * Time.deltaTime);
    }
}