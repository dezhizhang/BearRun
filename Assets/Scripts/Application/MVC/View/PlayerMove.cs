using UnityEngine;
using static Consts;
public class PlayerMove : View
{
    // 人物移动速度
    public float speed = 20.0f;
    private CharacterController _mcc;
    
    private InputDirection _inputDir = InputDirection.Null;
    
    private bool _activeInput = false;

    // 按下的位置
    private Vector3 _mousePos;
    // 获取视图名称
    public override string Name  {
        get
        {
            return V_PlayerMove;
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
        GetInputDirection();
    }


    private void GetInputDirection()
    {
        _inputDir = InputDirection.Null;
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && _activeInput)
        {
            Vector3 dir = Input.mousePosition - _mousePos;
            if (dir.magnitude > 20)
            {
                
                Debug.Log(dir);
            }
        }

    }

}
