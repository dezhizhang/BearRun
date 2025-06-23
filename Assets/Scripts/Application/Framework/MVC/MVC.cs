using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class MVC
{
  // 模型对像集合
  public static Dictionary<string,Model> models = new Dictionary<string, Model>();
  // 视图对像集合
  public static Dictionary<string,View> views = new Dictionary<string, View>();
  // 定义事件对像集合
  public static Dictionary<string,Type> commandMap = new Dictionary<string,Type>();

  // 注册视图
  public static void RegisterView(View view)
  {
    views.Add(view.Name, view);
  }
  
  // 注册模型
  public static void RegisterModel(Model model)
  {
    models.Add(model.Name, model);
  }
  
  // 注册控制器
  public static void RegisterController(string eventName, Type controllerType)
  {
    commandMap.Add(eventName,controllerType);
  }

  // 获取模型视图
  public static T GetModel<T>() where T : Model
  {
    foreach (Model m in models.Values)
    {
      if (m is T)
      {
        return (T)m;
      }
    }
    return null;
  }

  // 获取视图对像
  public static View GetView<T>() where T : View
  {
    foreach (View v in views.Values)
    {
      if (v is T)
      {
        return (T)v;
      }
    }
    return null;
  }

}
