using UnityEngine;

/// <summary>
/// 单例的模板类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class MonoSignleton<T> : MonoBehaviour where T : MonoSignleton<T>
{
    // 保留单例实例静态字段
    private static T _instance;

    /// <summary>
    /// 获取实例
    /// </summary>
    public static T Instance
    {
        get { return _instance; }
    }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}