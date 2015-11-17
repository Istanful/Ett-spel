using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScrollRectSnap : MonoBehaviour
{
    public bool loopPanels;
    public float panelLerpStrength;
    public RectTransform scrollPanel;
    public RectTransform[] subPanel;
    public RectTransform centerMarker;

    public float[] distance;
    public float[] distReposition;
    bool dragging = false;
    int subPanelDistance;
    int minSubPanelNum;
    int subPanelLength;

    void Start()
    {
        subPanelLength = subPanel.Length;
        distance = new float[subPanelLength];
        distReposition = new float[subPanelLength];

        subPanelDistance = (int)Mathf.Abs(subPanel[1].GetComponent<RectTransform>().anchoredPosition.x - subPanel[0].GetComponent<RectTransform>().anchoredPosition.x);
    }

    void Update()
    {
        for (int i = 0; i < subPanel.Length; i++)
        {
            distReposition[i] = centerMarker.GetComponent<RectTransform>().position.x - subPanel[i].transform.position.x;
            distance[i] = Mathf.Abs(distReposition[i]);

            #region loopPanels
            if (loopPanels)
            {

                if (distReposition[i] > 1500)
                {
                    float curX = subPanel[i].GetComponent<RectTransform>().anchoredPosition.x;
                    float curY = subPanel[i].GetComponent<RectTransform>().anchoredPosition.y;

                    Vector2 newAnchoredPosition = new Vector2(curX + (subPanelLength * subPanelDistance), curY);
                    subPanel[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPosition;
                }

                if (distReposition[i] < -1500)
                {
                    float curX = subPanel[i].GetComponent<RectTransform>().anchoredPosition.x;
                    float curY = subPanel[i].GetComponent<RectTransform>().anchoredPosition.y;

                    Vector2 newAnchoredPosition = new Vector2(curX - (subPanelLength * subPanelDistance), curY);
                    subPanel[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPosition;
                }
            }
            #endregion
            float minDistance = Mathf.Min(distance);
            for (int a = 0; a < subPanel.Length; a++)
            {
                if (minDistance == distance[a])
                    minSubPanelNum = a;
            }

            if (!dragging)
            {//LerpToPanel(minSubPanelNum * -subPanelDistance);
                LerpToPanel(-subPanel[minSubPanelNum].GetComponent<RectTransform>().anchoredPosition.x);
            }
        }
    }

    void LerpToPanel(float position)
    {
        float newX = Mathf.Lerp(scrollPanel.anchoredPosition.x, position, Time.deltaTime * panelLerpStrength);
        Vector2 newPosition = new Vector2(newX, scrollPanel.anchoredPosition.y);

        scrollPanel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }
}