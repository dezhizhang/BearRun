using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class PlayMove : View
{
    public float speed = 20.0f;

    // 输入方向
    private InputDir _inputDir = InputDir.Null;

    // 是否有输入
    private bool _activeInput = false;
    private Vector3 _mousePos;

    private CharacterController _controller;

    public override string Name
    {
        get { return Constants.V_PLAY_MOVE; }
    }


    public override void HandleEvent(string eventName, object data)
    {
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _controller.Move(transform.forward * speed * Time.deltaTime);
        GetInputDir();
    }

    private void GetInputDir()
    {
        // 重置输入方向
        _inputDir = InputDir.Null;
        // 鼠标按下时
        if (Input.GetMouseButtonDown(0))
        {
            _activeInput = true;
            // 获取初始位置
            _mousePos = Input.mousePosition;
        }

        // 鼠标持续按下时
        if (Input.GetMouseButton(0) && _activeInput)
        {
            Vector3 dir = Input.mousePosition - _mousePos;
            if (dir.magnitude > 20f)
            {
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y) && dir.x > 0)
                {
                    // 向右滑动
                    _inputDir = InputDir.Right;
                }

                else if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y) && dir.x < 0)
                {
                    // 向左移动
                    _inputDir = InputDir.Left;
                }
                else if (Mathf.Abs(dir.y) > Mathf.Abs(dir.x) && dir.y > 0)
                {
                    // 向上移动
                    _inputDir = InputDir.Up;
                }
                else if (Mathf.Abs(dir.y) > Mathf.Abs(dir.x) && dir.y < 0)
                {
                    // 向下移动
                    _inputDir = InputDir.Down;
                }
            }

            _activeInput = false;
        }

        // 按键按下事件上下左右
        if (Input.GetKey(KeyCode.W))
        {
            _inputDir = InputDir.Up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _inputDir = InputDir.Down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _inputDir = InputDir.Left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _inputDir = InputDir.Right;
        }
    }
}