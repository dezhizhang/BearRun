public static class Constants
{
    /// <summary>
    /// 事件名称
    /// </summary>
    // 退出场景
    public const string E_EXIT_SCENES = "e_exit_scenes";

    // 加载场景
    public const string E_ENTER_SCENES = "e_enter_scenes";

    // 启动控制器
    public const string E_START_UP_CONTROLLER = "e_start_up_controller";

    /// <summary>
    /// SendMessage事件函数
    /// </summary>
    public const string E_ANIM_MANAGER = "AnimManager";

    /// <summary>
    /// 视图名称
    /// </summary>
    public const string V_PLAY_MOVE = "v_play_move";

    // 玩家动画
    public const string V_PLAY_ANIMATION = "v_play_animation";

    // 玩家跑动画
    public const string A_RUN = "run";

    // 玩家滚动动画
    public const string A_ROLL = "roll";

    // 玩家向上跳跃动画
    public const string A_JUMP = "jump";

    // 玩家向左跳动画
    public const string A_LEFT_JUMP = "left_jump";

    // 玩家向右跳跃动画
    public const string A_RIGHT_JUMP = "right_jump";


    /// <summary>
    /// 输入方向
    /// </summary>
    public enum InputDir
    {
        Null,
        Right,
        Left,
        Up,
        Down,
    }
}