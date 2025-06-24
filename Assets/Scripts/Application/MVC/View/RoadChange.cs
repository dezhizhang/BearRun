using UnityEngine;

public class RoadChange : MonoBehaviour
{
    [HideInInspector]
    public GameObject roadNow;
    [HideInInspector]
    public GameObject roadNext;
    [HideInInspector]
    public GameObject parent;

    private void Start()
    {
        if (parent == null)
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
        
        int index = Random.Range(1, 5);
        
        roadNow = roadNext;
        roadNext = Game.Instance.objectPool.Spawn($"Pattern_{index}",parent.transform);
        roadNext.transform.position = roadNow.transform.position + new Vector3(0, 0, 160);
    }
}
