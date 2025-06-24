using UnityEngine;

public static class Consts
{
    // 退出程序
    public const string E_ExitScenes = "E_ExitScene";
    // 加载新场景
    public const string E_EnterScenes = "E_EnterScene";
    // 
    public const string E_StartUp = "E_StartUp";
    
    // 视图名称
    public const string V_PlayerMove = "V_PlayerMove";
    // 玩家动画
    public const string V_PlayerAnim = "V_PlayerAnim";

    public enum InputDirection
    {
        Null,
        Right,
        Left,
        Up,
        Down,
    }
    
}
