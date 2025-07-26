using System;


public abstract class Controller
{
    public abstract void Execute(object data);


    /// <summary>
    /// 获取模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected T GetModel<T>() where T : Model
    {
        return MVC.GetModel<T>() as T;
    }

    /// <summary>
    /// 获取视图
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected T GetView<T>() where T : View
    {
        return MVC.GetView<T>() as T;
    }

    /// <summary>
    /// 注册视图层
    /// </summary>
    /// <param name="view"></param>
    protected void RegisterView(View view)
    {
        MVC.RegisterView(view);
    }

    /// <summary>
    /// 注册模型层
    /// </summary>
    /// <param name="model"></param>
    protected void RegisterModel(Model model)
    {
        MVC.RegisterModel(model);
    }

    /// <summary>
    /// 注册控制器层
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="controllerType"></param>
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}