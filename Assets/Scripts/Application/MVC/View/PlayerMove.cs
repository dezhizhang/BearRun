using System;
using UnityEngine;
using static Consts;

public class PlayerMove : View
{
    // 人物移动速度
    public float speed = 20.0f;

    // 车道间的间距
    public float laneDistance = 2.0f;

    // 玩家当前所在的车道
    public int playerCurrentLane = 0;
    private CharacterController _mcc;

    private InputDirection _inputDir = InputDirection.Null;

    private bool _activeInput = false;


    // 按下的位置
    private Vector3 _mousePos;

    // 获取视图名称
    public override string Name
    {
        get { return V_PlayerMove; }
    }

    public override void HandleEvent(string eventName, object data)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        _mcc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 获取输入方向
        GetInputDirection();
        // 更新位置
        UpdatePosition();
        // 玩家移动
        PlayerDoMove();
    }


    private void GetInputDirection()
    {
        _inputDir = InputDirection.Null;
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Input.mousePosition;
        }

        // 手机输入法
        if (Input.GetMouseButton(0) && _activeInput)
        {
            Vector3 dir = Input.mousePosition - _mousePos;
            if (dir.magnitude > 20)
            {
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y) && dir.x > 0)
                {
                    _inputDir = InputDirection.Right;
                }
                else if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y) && dir.x < 0)
                {
                    _inputDir = InputDirection.Left;
                }
                else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y) && dir.y > 0)
                {
                    _inputDir = InputDirection.Up;
                }
                else if (Mathf.Abs(dir.y) > Mathf.Abs(dir.x) && dir.x < 0)
                {
                    _inputDir = InputDirection.Down;
                }

                _activeInput = false;
            }
        }

        // 电脑按键输入
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.Space))
        {
            _inputDir = InputDirection.Up;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            _inputDir = InputDirection.Down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _inputDir = InputDirection.Left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _inputDir = InputDirection.Right;
        }

        _activeInput = false;
    }

    // 
    private void UpdatePosition()
    {
        switch (_inputDir)
        {
            case InputDirection.Null:
                break;
            case InputDirection.Up:
                break;
            case InputDirection.Down:
                break;
            case InputDirection.Left:
                MoveLane(false);
                break;
            case InputDirection.Right:
                MoveLane(true);
                break;
            default:
                break;
        }

        if (_inputDir != InputDirection.Null)
        {
            SendMessage("AnimManager",_inputDir);
        }
    }


    // 玩家移动
    private void PlayerDoMove()
    {
        // 移动的距离
        float targetX = playerCurrentLane * laneDistance;
        Vector3 targetPos = new Vector3(targetX, transform.position.y, transform.position.z);
        // 移动方向
        Vector3 moveDir = targetPos - transform.position;

        _mcc.Move((moveDir + transform.forward) * speed * Time.deltaTime);
    }

    // 调整玩家移动车道
    private void MoveLane(bool right)
    {
        playerCurrentLane = playerCurrentLane + (right ? 1 : -1);
        // 约束移动的距离
        playerCurrentLane = Mathf.Clamp(playerCurrentLane, -1, 1);
    }
}