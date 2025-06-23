using UnityEngine;
using System;

public abstract class Controller 
{
  // 执行命令的抽像方法，需要子类实现的具体逻辑
  public abstract void Execte(object data);
  
  // 获取模型
  protected T GetModel<T>() where T : Model
  {
    return MVC.GetModel<T>();
  }
  
  // 获取视图
  protected T GetView<T>() where T : View
  {
    return MVC.GetView<T>() as T;
  }
  
  // 注册视图
  protected void RegisterView(View view)
  {
    MVC.RegisterView(view);
  }
  
  // 注册模型
  protected void RegisterModel(Model model)
  {
    MVC.RegisterModel(model);
  }
  
  // 注册控制器
  protected void RegisterController(string eventName, Type controllerType)
  {
    MVC.RegisterController(eventName, controllerType);
  }
  
}
