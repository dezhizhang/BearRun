using UnityEngine;

public class EnterSceneController : Controller
{
    public override void Execte(object data)
    {
        ScenesArgs e = data as ScenesArgs;
        switch (e.scenesIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 4:
                RegisterView(GameObject.FindWithTag("player").GetComponent<PlayerMove>());
                break;
            default:
                break;
        }
    }
}