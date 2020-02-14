using UnityEngine;
using PluggableFSM;

[CreateAssetMenu(menuName=Paths.actions + "test")]
public class TestAction : Action
{
    public override void Enter(Controller controller)
    {
        Debug.Log(name + " entered");
    }

    public override void Exit()
    {
        Debug.Log(name + " exited");
    }

    public override void Tick(Controller controller)
    {
        Debug.Log(name + " ticked");
    }
}
