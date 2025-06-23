using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T:MonoBehaviour
{
   // 保留单例的静态字段
   private static T _instance;
   // 单例实例只读属性
   public static T Instance
   {
      get => _instance;
   }
   
   // 确保只有一个单例
   protected virtual void Awake()
   {
      _instance = this as T;
   }

}
