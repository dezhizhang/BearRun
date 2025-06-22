using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
   // 资源的路径
   public string resourceDir;
   // 存储不同类型对像池字典 
   Dictionary<string,SubPool> m_pools = new Dictionary<string,SubPool>();

   // 指出指定名称的物体
   public GameObject Spawn(string name,Transform trans)
   {
      SubPool pool = null;
      if (!m_pools.ContainsKey(name))
      {
         // 注册对像池
         RegisterNew(name,trans);
      }
      pool = m_pools[name];
      return pool.Spawn();
   }

   // 注册一个新的子池子
   private void RegisterNew(string name,Transform trans)
   {
      // 构建资源路径
      string path = resourceDir + "/" + name;
      // 加载资源路径
      GameObject go = Resources.Load<GameObject>(path);
      // 创建一个对像池
      SubPool pool = new SubPool(trans,go);
      // 创建的子池子放入字典中
      m_pools.Add(pool.Name,pool);
   }
   
   //  回收单个物体方法
   public void UnSpawn(GameObject go)
   {
      SubPool pool = null;
      foreach (SubPool p in m_pools.Values)
      {
         // 查找到指定的对像
         if (p.Contain(go))
         {
            pool = p;
            break;
         }
      }

      if (pool != null)
      {
         // 回收物体
         pool.UnSpawn(go);
      }
   }
   
   // 回收所有物体
   public void UnSpawnAll()
   {
      foreach (SubPool p in m_pools.Values)
      {
         p.UnSpawnAll();
      }
   }
   
}
