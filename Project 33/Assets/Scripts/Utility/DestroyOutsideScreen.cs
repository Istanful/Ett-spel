using UnityEngine;
using System.Collections;

public class DestroyOutsideScreen : MonoBehaviour {
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
