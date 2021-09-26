using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    [SerializeField] private Board board;
    [SerializeField] private float swipeThreshold = 50f;
    [SerializeField] private float timeThreshold = 0.3f;


    private Vector2 _fingerDown;
    private DateTime _fingerDownTime;

    private Vector2 _fingerUp;
    private DateTime _fingerUpTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _fingerDown = Input.mousePosition;
            _fingerUp = Input.mousePosition;
            _fingerDownTime = DateTime.Now;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _fingerDown = Input.mousePosition;
            _fingerUpTime = DateTime.Now;
            CheckSwipe();
        }
    }

    private void CheckSwipe()
    {
        float duration = (float) _fingerUpTime.Subtract(_fingerDownTime).TotalSeconds;
        if (duration > timeThreshold) return;

        float deltaX = _fingerDown.x - _fingerUp.x;
        float deltaY = _fingerDown.y - _fingerUp.y;

        if (Math.Abs(deltaX) > Math.Abs(deltaY))
        {
            if (Mathf.Abs(deltaX) > swipeThreshold)
            {
                if (deltaX > 0)
                {
                    Debug.Log("right");
                }
                else if (deltaX < 0)
                {
                    Debug.Log("left");
                }
            }
        }
        else
        {
            if (Mathf.Abs(deltaY) > swipeThreshold)
            {
                if (deltaY > 0)
                {
                    Debug.Log("up");
                }
                else if (deltaY < 0)
                {
                    Debug.Log("down");
                }
            }
        }


        _fingerUp = _fingerDown;
    }
}