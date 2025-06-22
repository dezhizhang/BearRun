using UnityEngine;
using System.Collections.Generic;

public class SubPool
{
    //游戏物体集合
    List<GameObject> m_objects = new List<GameObject>();

    //存储GameObject预质体
    GameObject m_prefab;

    //获取预质体名字
    public string Name
    {
        get { return m_prefab.name; }
    }

    //父物体位置
    Transform m_Parent;

    //构造函数
    public SubPool(Transform parent, GameObject go)
    {
        m_Parent = parent;
        m_prefab = go;
    }

    // 生成对像的方法
    public GameObject Spawn()
    {
        GameObject go = null;
        // 检查集合是否存在没有使用的
        foreach (GameObject obj in m_objects)
        {
            // 没有被使用
            if (!obj.activeSelf)
            {
                go = obj;
                break;
            }
        }

        // 没有不在使用的情况
        if (go == null)
        {
            // 直接指定父对象
            go = GameObject.Instantiate<GameObject>(m_prefab, m_Parent);
            m_objects.Add(go);
            m_objects.Add(go);
        }
        // 设置属性调用接口方法
        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
        return go;
    }

 
    // 回收对像池物体
    public void UnSpawn(GameObject go)
    {
        if (m_objects.Contains(go))
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    // 回收对像池所有物体
    public void UnSpawnAll()
    {
        foreach (GameObject go in m_objects)
        {
            if (go.activeSelf)
            {
                UnSpawn(go);
            }
        }
    }
}