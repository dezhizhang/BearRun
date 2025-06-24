using UnityEngine;

public class PlayerMove : View
{
    // 人物移动速度
    public float speed = 20.0f;
    private CharacterController _mcc;
    // 获取视图名称
    public override string Name  {
        get
        {
            return Consts.V_PlayerMove;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        _mcc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 人物移动
        _mcc.Move(transform.forward * speed * Time.deltaTime);
    }
    
}
