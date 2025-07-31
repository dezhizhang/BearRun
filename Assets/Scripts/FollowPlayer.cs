using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 跟随相机移动
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    private Transform _player;
    private Vector3 _offset;
    private float _speed;

    private void Awake()
    {
        _speed = 20.0f;
        _player = GameObject.FindWithTag("Player").transform;
        _offset = transform.position - transform.position;
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(
            _offset.x + _player.position.x,
            transform.position.y,
            _offset.z + _player.position.z
        );
        
        // 平滑移动
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _speed);
    }
}