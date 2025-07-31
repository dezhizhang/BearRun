using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

/// <summary>//
/// 玩家动画
/// </summary>
public class PlayerAnimation : View
{
    private Animation _animation;

    // 事件委牧
    Action PlayAnimation;

    public override string Name
    {
        get { return Constants.V_PLAY_ANIMATION; }
    }

    public override void HandleEvent(string name, object data)
    {
    }

    private void Awake()
    {
        // 获取玩家动画
        _animation = GetComponent<Animation>();
        PlayAnimation = PlayRun;
    }

    private void Update()
    {
        PlayAnimation();
    }

    public void AnimManager(InputDir dir)
    {
        switch (dir)
        {
            case InputDir.Null:
                break;
            case InputDir.Left:
                PlayAnimation = PlayLeft;
                break;
            case InputDir.Right:
                PlayAnimation = PlayRight;
                break;
            case InputDir.Up:
                PlayAnimation = PlayJump;
                break;
            case InputDir.Down:
                PlayAnimation = PlayRoll;
                break;
            default:
                break;
        }
    }

    private void PlayRun()
    {
        _animation.Play(A_RUN);
    }

    /// <summary>
    /// 向左播放动画
    /// </summary>
    private void PlayLeft()
    {
        _animation.Play(Constants.A_LEFT_JUMP);
        // 播放时长大于0.95时退出动画
        if (_animation[Constants.A_LEFT_JUMP].normalizedTime >= 0.95)
        {
            PlayAnimation = PlayRun;
        }
    }

    /// <summary>
    /// 向右跳跃动画
    /// </summary>
    private void PlayRight()
    {
        _animation.Play(Constants.A_RIGHT_JUMP);
        if (_animation[Constants.A_RIGHT_JUMP].normalizedTime >= 0.95)
        {
            PlayAnimation = PlayRun;
        }
    }

    /// <summary>
    /// 玩家滚动动画
    /// </summary>
    private void PlayRoll()
    {
        _animation.Play(Constants.A_ROLL);
        if (_animation[Constants.A_ROLL].normalizedTime >= 0.95)
        {
            PlayAnimation = PlayRun;
        }
    }

    /// <summary>
    /// 玩家向上跳跃动画
    /// </summary>
    private void PlayJump()
    {
        _animation.Play(Constants.A_JUMP);
        if (_animation[Constants.A_JUMP].normalizedTime >= 0.95)
        {
            PlayAnimation = PlayRun;
        }
    }
}