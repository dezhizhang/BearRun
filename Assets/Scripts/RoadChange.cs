using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 道路改变脚本
/// </summary>
public class RoadChange : MonoBehaviour
{
    // 当前道路
    [HideInInspector] public GameObject roadNow;

    // 下一条道路
    [HideInInspector] public GameObject roadNext;

    // 父对像
    [HideInInspector] public GameObject parent;

    private void Start()
    {
        if (parent == null)
        {
            // 初始化父对像
            parent = new GameObject();
            parent.SetActive(true);
            parent.transform.position = Vector3.zero;
            parent.name = "Road";
        }
        
  
        // 创建道路
        roadNow = Game.Instance.objectPool.Spawn("Pattern_1", parent.transform);
        roadNext = Game.Instance.objectPool.Spawn("Pattern_2", parent.transform);

        roadNext.transform.position += new Vector3(0, 0, 160);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            // 回收对像
            Game.Instance.objectPool.UnSpawn(other.gameObject);
            SpawnNewRoad();
        }
    }

    /// <summary>
    /// 生成道路
    /// </summary>
    private void SpawnNewRoad()
    {
        int index = Random.Range(1, 5);
        roadNow = roadNext;
        roadNext = Game.Instance.objectPool.Spawn("Pattern_" + index, parent.transform);
        roadNext.transform.position += roadNow.transform.position + new Vector3(0, 0, 160);
    }
}