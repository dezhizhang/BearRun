using System.Collections.Generic;

public abstract class View
{
    public abstract string Name { get; }

    public List<string> attentionList = new List<string>();

    public abstract void HandleEvent(string eventName, object data);

    /// <summary>
    /// 发送事件
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="data"></param>
    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }


    /// <summary>
    /// 获取模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected T GetModel<T>() where T : Model
    {
        return MVC.GetModel<T>() as T;
    }

    public void RegisterAttentionEvent()
    {
    }
}