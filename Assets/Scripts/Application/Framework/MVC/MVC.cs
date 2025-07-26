using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MVC
{
    // 模型字典
    public static Dictionary<string, Model> models = new Dictionary<string, Model>();

    // 视图字典
    public static Dictionary<string, View> views = new Dictionary<string, View>();

    // 命令字典
    public static Dictionary<string, Type> commandMap = new Dictionary<string, Type>();


    /// <summary>
    /// 注册视图
    /// </summary>
    /// <param name="view"></param>
    public static void RegisterView(View view)
    {
        views.Add(view.Name, view);
    }

    /// <summary>
    /// 注册模型
    /// </summary>
    /// <param name="model"></param>
    public static void RegisterModel(Model model)
    {
        models.Add(model.Name, model);
    }

    /// <summary>
    /// 注册控制器
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="controllerType"></param>
    public static void RegisterController(string eventName, Type controllerType)
    {
        commandMap.Add(eventName, controllerType);
    }
}