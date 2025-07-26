using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// 对像池物体
/// </summary>
public class ObjectPool : MonoBehaviour
{
    // 资源目录
    public string resourceDir;

    // 存储不同类型的subpool的字典
    private Dictionary<string, SubPool> _pools = new Dictionary<string, SubPool>();

    /// <summary>
    /// 返回指定名称的物体
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject Spawn(string name, Transform trans)
    {
        SubPool pool;
        if (!_pools.ContainsKey(name))
        {
            RegisterNew(name, trans);
        }

        pool = _pools[name];
        return pool.Spawn();
    }

    /// <summary>
    /// 注册一个对像池
    /// </summary>
    /// <returns></returns>
    public void RegisterNew(string name, Transform trans)
    {
        string path = resourceDir + "/" + name;

        GameObject go = Resources.Load<GameObject>(path);

        SubPool pool = new SubPool(trans, go);
        _pools.Add(pool.Name, pool);
    }
}