using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public GameObject followObject;
    public float xOffset;
    public float yOffset;

    void Update ()
	{
        if (followObject != null)
		    transform.position = new Vector3 (followObject.transform.position.x + xOffset, followObject.transform.position.y + yOffset, transform.position.z);
	}
}