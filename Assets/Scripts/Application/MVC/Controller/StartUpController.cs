using UnityEngine;

public class StartUpController:Controller
{
   public override void Execte(object data)
   {
      // 注册所有的其它控制器
      RegisterController(Consts.E_EnterScenes,typeof(EnterSceneController));
      // 注册模型
      RegisterModel(new GameModel());
      
   }
}
