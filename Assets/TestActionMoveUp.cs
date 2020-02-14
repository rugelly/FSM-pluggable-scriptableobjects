using UnityEngine;
using PluggableFSM;

[CreateAssetMenu(menuName=Paths.actions + "move up")]
public class TestActionMoveUp : Action
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
        if (Input.GetKey(KeyCode.Space))
            controller.cc.Move(Vector3.up * 5 * Time.deltaTime);
        else
            controller.cc.Move(Vector3.down * 3 * Time.deltaTime);
    }
}
