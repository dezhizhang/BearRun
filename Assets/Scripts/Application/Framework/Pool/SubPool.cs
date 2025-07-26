using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPool
{
    // 游戏物体集合
    private List<GameObject> _objects = new List<GameObject>();

    // 预质体
    private GameObject _perfab;

    // 父物体的位置
    private Transform _parent;

    // 获取预质体名称
    public string Name
    {
        get { return _perfab.name; }
    }

    // 构造函数
    public SubPool(Transform parent, GameObject go)
    {
        _parent = parent;
        _perfab = go;
    }

    /// <summary>
    /// 创建对偈池物体
    /// </summary>
    /// <returns></returns>
    public GameObject Spawn()
    {
        GameObject go = null;
        // 检查集合是否有存在未使用的
        foreach (var obj in _objects)
        {
            // 如果当前没有被使用
            if (!obj.activeSelf)
            {
                go = obj;
                break;
            }
        }

        if (!go)
        {
            //如果集合中不存在则生成
            go = GameObject.Instantiate(_perfab, _parent);
            _objects.Add(go);
        }

        // 设置为true保险起见
        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

        return go;
    }

    /// <summary>
    /// 回收对像池物体
    /// </summary>
    /// <param name="go"></param>
    public void UnSpawn(GameObject go)
    {
        // 判断是否
        if (_objects.Contains(go))
        {
            // 发送消息
            go.SetActive(false);
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
        }
    }


    /// <summary>
    /// 回收所有对像池物体
    /// </summary>
    public void UnSpawnAll()
    {
        foreach (var obj in _objects)
        {
            if (obj.activeSelf)
            {
                UnSpawn(obj);
            }
        }
    }
}