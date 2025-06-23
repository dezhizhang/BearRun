using UnityEngine;
using System.Collections.Generic;

public abstract class View : MonoBehaviour
{
  public abstract string Name { get; }
  
  public List<string> attentionList = new List<string>();
  
  // 处理事件的抽像方法，
  public abstract void HandleEvent(string eventName, object data);

  public void RegisterAttentionEvent()
  {
    
  }

  // 发送事件
  protected void SendEvent(string eventName, object data = null)
  {
    MVC.SendEvent(eventName, data);
  }
  
  // 获取模型
  protected T GetModel<T>() where T : Model
  {
    return MVC.GetModel<T>() as T;
  }
  
}
