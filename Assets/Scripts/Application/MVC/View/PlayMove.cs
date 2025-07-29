using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : View
{
    public float speed = 20.0f;

    private CharacterController _controller;

    public override string Name
    {
        get { return Constants.V_PLAY_MOVE; }
    }


    public override void HandleEvent(string eventName, object data)
    {
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _controller.Move(transform.forward * speed * Time.deltaTime);
    }
}