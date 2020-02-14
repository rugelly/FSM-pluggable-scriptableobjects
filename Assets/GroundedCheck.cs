using UnityEngine;
using PluggableFSM;

[CreateAssetMenu(menuName=Paths.connections + "Grounded")]
public class GroundedCheck : Connection
{
    public override bool Eval(Controller controller)
    {
        Debug.Log(name + " evaluating...");
        return controller.cc.isGrounded;
    }
}
