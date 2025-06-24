using UnityEngine;
using static Consts;
using System;

public class PlayerAnim:View
{
    Animation _animation;
    Action _playerAnim;
    public override string Name
    {
        get { return V_PlayerAnim; }
    }

    public override void HandleEvent(string eventName, object data)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        _playerAnim = PlayerRun;
    }

    private void Update()
    {
        _playerAnim();
    }

    public void AnimManager(InputDirection direction)
    {
        switch (direction)
        {
            case InputDirection.Null:
                break;
            case InputDirection.Up:
                _playerAnim = PlayerJump;
                break;
            case InputDirection.Down:
                _playerAnim = PlayerRoll;
                break;
            case InputDirection.Left:
                _playerAnim = PlayerLeft;
                break;
            case InputDirection.Right:
                _playerAnim = PlayerRight;
                break;
            default:
                break;
        }
    }

    private void PlayerRun()
    {
        _animation.Play("run");
    }

    private void PlayerLeft()
    {
        _animation.Play("left_jump");
        if (_animation["left_jump"].normalizedTime >= 0.95)
        {
            _playerAnim = PlayerRun;
        }
    }

    private void PlayerRight()
    {
        _animation.Play("right_jump");
        if (_animation["right_jump"].normalizedTime >= 0.95)
        {
            _playerAnim = PlayerRun;
        }
    }

    private void PlayerRoll()
    {
        _animation.Play("roll");
        if (_animation["roll"].normalizedTime >= 0.95)
        {
            _playerAnim = PlayerRun;
        }
    }

    private void PlayerJump()
    {
        _animation.Play("jump");
        if (_animation["jump"].normalizedTime >= 0.95)
        {
            _playerAnim = PlayerRun;
        } 
    }
    

}
