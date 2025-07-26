using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPool : MonoBehaviour
{
    // 游戏物体集合
    List<GameObject> _objects = new List<GameObject>();

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
}