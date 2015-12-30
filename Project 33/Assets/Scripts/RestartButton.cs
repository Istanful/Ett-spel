using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {
    public void Restart()
    {
        GameController.Reset();
        GameController.GoToMainMenu();
    }
}
