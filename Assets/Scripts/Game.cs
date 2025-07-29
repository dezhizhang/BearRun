using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// 组件自动挂载
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(StaticData))]
public class Game : MonoSignleton<Game>
{
    // 隐藏属性
    [HideInInspector]
    // 全局声音 
    public Sound sound;

    // 隐藏属性
    [HideInInspector]
    //  全局对像池
    public ObjectPool objectPool;

    // 隐藏属性
    // 隐藏属性
    [HideInInspector]
    // 全局对像数据
    public StaticData staticData;


    /// <summary>
    /// 初始化实例
    /// </summary>
    private void Start()
    {
        // 场景切换时不被毁销
        DontDestroyOnLoad(this);
        sound = Sound.Instance;
        objectPool = ObjectPool.Instance;
        staticData = StaticData.Instance;

        // 注册开始控制器
        RegisterController(Constants.E_START_UP_CONTROLLER, typeof(StartUpController));
        // 加载关卡
        Game.Instance.LoadLevel(4);
    }

    /// <summary>
    /// 加载关卡
    /// </summary>
    public void LoadLevel(int level)
    {
        SceneArgs sceneArgs = new SceneArgs()
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex
        };

        // 发送事件关卡
        SendEvent(Constants.E_EXIT_SCENES, sceneArgs);

        // 发送退出场景
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="level"></param>
    private void OnLevelWasLoaded(int level)
    {
        SceneArgs sceneArgs = new SceneArgs
        {
            sceneIndex = level
        };
        // 发送加载场景
        SendEvent(Constants.E_ENTER_SCENES, sceneArgs);
    }

    /// <summary>
    /// 发送事件方法
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="data"></param>
    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    /// <summary>
    ///  注册控制器
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="controllerType"></param>
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}