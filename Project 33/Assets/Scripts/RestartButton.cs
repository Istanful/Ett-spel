using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {
    public void Restart()
    {
        GameController.ResetPoints();
        GameController.GoToMainMenu();
    }
}
