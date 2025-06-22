using UnityEngine;

public abstract class IReusableObject : MonoBehaviour,IReusable
{
   // 抽像方法
   public abstract void OnSpawn();
   public abstract void OnUnSpawn();
}


