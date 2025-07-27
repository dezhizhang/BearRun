using System;
using System.Collections.Generic;

public abstract class MVC
{
    // 模型字典
    public static Dictionary<string, Model> models = new Dictionary<string, Model>();

    // 视图字典
    public static Dictionary<string, View> views = new Dictionary<string, View>();

    // 命令字典
    public static Dictionary<string, Type> commandMap = new Dictionary<string, Type>();


    /// <summary>
    /// 注册模型
    /// </summary>
    /// <param name="model"></param>
    public static void RegisterModel(Model model)
    {
        
        models.Add(model.Name, model);
    }

    /// <summary>
    /// 注册视图
    /// </summary>
    /// <param name="view"></param>
    public static void RegisterView(View view)
    {
        // 如果存在则移除
        if (views.ContainsKey(view.Name))
        {
            // 防止重复注册
            views.Remove(view.Name);
        }

        view.RegisterAttentionEvent();
        views.Add(view.Name, view);
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

    /// <summary>
    /// 获取模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetModel<T>() where T : Model
    {
        foreach (var model in models.Values)
        {
            if (model is T)
            {
                return (T)model;
            }
        }

        return null;
    }

    /// <summary>
    /// 获取视图
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetView<T>() where T : View
    {
        foreach (var view in views.Values)
        {
            if (view is T)
            {
                return (T)view;
            }
        }

        return null;
    }

    /// <summary>
    /// 发送事件
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="data"></param>
    public static void SendEvent(string eventName, object data = null)
    {
        if (commandMap.ContainsKey(eventName))
        {
            Type commandType = commandMap[eventName];
            // 能过反射实例化控制器
            Controller c = Activator.CreateInstance(commandType) as Controller;
            if (c != null)
            {
                c.Execute(data);
            }
        }


        foreach (var view in views.Values)
        {
            if (view.attentionList.Contains(eventName))
            {
                // 执行对应事件名称
                view.HandleEvent(eventName, data);
            }
        }
    }
}