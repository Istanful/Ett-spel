using UnityEngine;
using System.Collections;

public class Melvin : MonoBehaviour {
    public enum AiState { Idle };
    public AiState currentState;
    public int floatingSpeed;

    int currentFloatingSpeed;
    Vector3 originalPosition;

	void Start()
    {
        originalPosition = transform.localPosition;
        currentFloatingSpeed = floatingSpeed;
    }

    void Update()
    {
        switch (currentState)
        {
            case AiState.Idle:
                if (transform.localPosition.y >= (originalPosition.y + 1))
                    currentFloatingSpeed = -floatingSpeed;
                else if (transform.localPosition.y <= (originalPosition.y - 1))
                    currentFloatingSpeed = floatingSpeed;
                
                transform.Translate(Vector3.up * currentFloatingSpeed * Time.deltaTime, Space.Self);
                break;
        }
    }
}
