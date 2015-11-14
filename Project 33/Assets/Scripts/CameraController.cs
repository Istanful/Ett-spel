using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public GameObject followObject;

	void Update ()
	{
        if (followObject != null)
		    transform.position = new Vector3 (followObject.transform.position.x + 75, followObject.transform.position.y + 23.5f, transform.position.z);
	}
}