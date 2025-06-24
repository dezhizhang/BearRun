using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  // 玩家的位置
  private Transform _player;
  private Vector3 _offset;
  public float speed = 20.0f;


  private void Awake()
  {
    _player = GameObject.FindWithTag("Player").transform;
    _offset = transform.position - _player.position;
  }

  // 更新相机位置
  private void Update()
  {
    Vector3 targetPos = new Vector3(_offset.x + _player.position.x, transform.position.y, _player.position.z + _offset.z);
    transform.position = Vector3.Lerp(transform.position,targetPos,speed*Time.deltaTime);
  }

}
