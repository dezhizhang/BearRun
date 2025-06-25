using UnityEngine;
using UnityEngine.SceneManagement;
using System;


[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(Sound))]
[RequireComponent(typeof(StaticData))]
public class Game:MonoSingleton<Game>
{
   
    // 全局访问对像
    [HideInInspector]
    public Sound sound;
    [HideInInspector]
    public ObjectPool objectPool;
    [HideInInspector]
    public StaticData staticData;
    void Start()
    {
        // 添加关卡不被肖毁
        DontDestroyOnLoad(gameObject);
        // 获取单例实现
        sound = Sound.Instance;
        objectPool = ObjectPool.Instance;
        staticData = StaticData.Instance;
        // 注册开始控制器
        RegisterController(Consts.E_StartUp,typeof(StartUpController));
        // 游戏启动发送消息
        SendEvent(Consts.E_StartUp);
        // 跳转场景
        Game.Instance.LoadLevel(4);
        
    }

    
    public void LoadLevel(int level)
    {
        ScenesArgs args = new()
        {
            scenesIndex = SceneManager.GetActiveScene().buildIndex,
        };
        // 获取当前活越的编号
        args.scenesIndex = SceneManager.GetActiveScene().buildIndex;
        // 发送事件数据
        SendEvent(Consts.E_ExitScenes,args);
        // 加载新场景
        SceneManager.LoadScene(level,LoadSceneMode.Single);
    }

    // 加载新场景
    private void OnLevelWasLoaded(int level)
    {
        ScenesArgs args = new() 
        {
            scenesIndex = SceneManager.GetActiveScene().buildIndex,
        };
        args.scenesIndex = level;
        SendEvent(Consts.E_EnterScenes, args);
    }
    
    // 发送事件的方法，参数为事件和传递的数据
    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }
    
    // 注册控制器
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }

}
