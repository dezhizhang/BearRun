using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class PlayerMove : View
{
    public float speed = 20.0f;

    // 道路距离
    public float landDistance = 2.0f;

    // 当前所在车道
    public int currentLane = 0;

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
        GetInputDir();
        UpdateDir();
        DoMove();
    }

    /// <summary>
    /// 获取按键的移动方向
    /// </summary>
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

    /// <summary>
    /// 更新玩家移动方向
    /// </summary>
    private void UpdateDir()
    {
        switch (_inputDir)
        {
            case InputDir.Null:
                break;
            case InputDir.Up:
                break;
            case InputDir.Down:
                break;
            case InputDir.Left:
                MoveLane(false);

                break;
            case InputDir.Right:
                MoveLane(true);
                break;
            default:
                break;
        }

        SendMessage(Constants.E_ANIM_MANAGER, _inputDir);
    }

    private void DoMove()
    {
        float targetX = currentLane * landDistance;
        Vector3 targetPos = new Vector3(targetX, transform.position.y, transform.position.z);
        // 移动方向
        Vector3 moveDir = targetPos - transform.position;
        _controller.Move((moveDir + transform.forward) * speed * Time.deltaTime);
        // _controller.Move(transform.forward * speed * Time.deltaTime);
    }

    /// <summary>
    /// 移动的道路线
    /// </summary>
    private void MoveLane(bool right)
    {
        currentLane = currentLane + (right ? 1 : -1);
        currentLane = Mathf.Clamp(currentLane, -1, 1);
    }
}