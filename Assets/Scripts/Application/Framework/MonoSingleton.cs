using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T:MonoBehaviour
{
   // 保留单例的静态字段
   private static T m_instance;
   // 单例实例只读属性
   public static T Instance
   {
      get => m_instance;
   }
   
   // 确保只有一个单例
   protected virtual void Awake()
   {
      m_instance = this as T;
   }

}
