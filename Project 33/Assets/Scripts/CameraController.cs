using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public GameObject followObject;

	void Update ()
	{
        if (followObject != null)
		    transform.position = new Vector3 (followObject.transform.position.x + 65, followObject.transform.position.y + 24.5f, transform.position.z);
	}
}