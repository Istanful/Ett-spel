﻿using UnityEngine;

public enum Swipe { None, Tap, BackUp, BackDown, FrontUp, FrontDown, Front };

public class SwipeController : MonoBehaviour
{
    public float minSwipeLength = 5f;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    Vector2 firstClickPos;
    Vector2 secondClickPos;

    Vector2 lastPos;

    static Swipe _swipeDirection;

    public static Swipe swipeDirection {
        get {
            Swipe direction = _swipeDirection;
            _swipeDirection = Swipe.None;
            return direction;
        }
    }

    public float swipeRegisterTime = 0.1f;

    void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
                Invoke("CheckSwipeDirection", swipeRegisterTime);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            firstClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Invoke("CheckSwipeDirection", swipeRegisterTime);
        }
    }

    void CheckSwipeDirection()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            secondPressPos = new Vector2(t.position.x, t.position.y);
            currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
        }
        else if (Input.GetMouseButton(0))
        {
            secondClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector3(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);
        }
        else
        {
            _swipeDirection = Swipe.Tap;
            Debug.Log("Direction: " + _swipeDirection + " <color=gray>(Angle: 0°)</color>");
            return;
        }

        if (currentSwipe.magnitude < minSwipeLength)
        {
            _swipeDirection = Swipe.Tap;
            Debug.Log("Direction: " + _swipeDirection + " <color=gray>(Angle: 0°)</color>");
            return;
        }

        currentSwipe.Normalize();

        float angle = Vector3.Angle(Vector3.right, currentSwipe);

        if (currentSwipe.y < 0)
            angle = angle * -1;

        if (angle >= 30 && angle <= 80)
            _swipeDirection = Swipe.FrontUp;
        else if (angle >= -30 && angle <= 30)
            _swipeDirection = Swipe.Front;
        else if (angle >= -80 && angle <= -30)
            _swipeDirection = Swipe.FrontDown;
        else if (angle >= 80 && angle <= 180)
            _swipeDirection = Swipe.BackUp;
        else if (angle >= -180 && angle <= -80)
            _swipeDirection = Swipe.BackDown;

        Debug.Log("Direction: " + _swipeDirection + " <color=gray>(Angle: " + Mathf.RoundToInt(angle) + "°)</color>");
    }
}