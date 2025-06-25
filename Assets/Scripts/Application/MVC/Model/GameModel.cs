using UnityEngine;
using static Consts;



public class GameModel:Model
{

    #region 字段

    private bool _isPlay = true;
    private bool _isPasue = false;

    #endregion
    
    #region 属性

    public override string Name 
    {
        get => M_GameModel;
    }

    public bool IsPlay { get => _isPlay; set => _isPlay = value; }
    public bool IsPasue { get => _isPasue; set => _isPasue = value; }
    #endregion
  
}
