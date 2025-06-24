using System;
using UnityEngine;
using static Consts;

public class PlayerMove : View
{
    // 人物移动速度
    public float speed = 20.0f;
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
        // 人物移动
        _mcc.Move(transform.forward * speed * Time.deltaTime);
        GetInputDirection();
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
}