using UnityEngine;

public class RoadChange : MonoBehaviour
{
    public GameObject roadNow;
    public GameObject roadNext;
    public GameObject parent;

    private void Start()
    {
        if (parent != null)
        {
            parent = new GameObject();
            parent.transform.position = Vector3.zero;
            parent.name = "Road";
        }
        
        // 初始化物体生成
        roadNow = Game.Instance.objectPool.Spawn("Pattern_1",parent.transform);
        roadNext = Game.Instance.objectPool.Spawn("Pattern_2",parent.transform);
        
        roadNext.transform.position += new Vector3(0, 0, 160);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            // 回收道路对像
            Game.Instance.objectPool.UnSpawn(other.gameObject);
            SpawnNewRoad();
        }
    }

    private void SpawnNewRoad()
    {
        roadNow = roadNext;
        roadNext = Game.Instance.objectPool.Spawn("Pattern_4",parent.transform);
        roadNext.transform.position = roadNow.transform.position + new Vector3(0, 0, 160);
    }
}
