using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {
    public void Restart()
    {
        GameObject gc = GameObject.FindGameObjectWithTag("GameController");
        gc.SendMessage("ResetPoints");
        gc.SendMessage("GoToMainMenu");
    }
}
