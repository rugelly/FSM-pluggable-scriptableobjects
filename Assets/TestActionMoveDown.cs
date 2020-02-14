using UnityEngine;
using PluggableFSM;

[CreateAssetMenu(menuName=Paths.actions + "Move Down")]
public class TestActionMoveDown : Action
{
    public override void Enter(Controller controller)
    {
        Debug.Log(name + " entered");
    }

    public override void Exit()
    {
        Debug.Log(name + " exited");
    }

    public override void Tick(Controller c)
    {
        Debug.Log(name + " ticked");
        c.cc.Move(Vector3.down * 3 * Time.deltaTime);
    }
}
