using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoreboard : MonoBehaviour
{
    [Header("Animation")]
    public float animationSpeed;
    public float animationMinDistance;
    bool isAnimating = false;

    [Header("Text strings")]
    public string levelClearPrefix;
    public string levelClearSuffix;
    public string goldCollectedPrefix;
    public string goldCollectedSuffix;

    [Header("Text objects")]
    public Text levelClearText;
    public Text goldCollectedText;

    [Header("Quest text objects")]
    public Text questOneText;
    public Text questTwoText;
    public Text questThreeText;

    void Update()
    {
        if (isAnimating)
        {
            transform.position = Vector3.Lerp(transform.position, Vector3.zero, animationSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Vector3.zero) < animationMinDistance)
                isAnimating = false;
        }
    }

    public void ShowScoreboard(string levelName, int goldCollected)
    {
        levelClearText.text = levelClearPrefix + levelName + levelClearSuffix;
        goldCollectedText.text = goldCollectedPrefix + goldCollected + goldCollectedSuffix;
        isAnimating = true;
    }
}
