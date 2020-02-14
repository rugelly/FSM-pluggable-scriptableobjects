using UnityEngine;
using PluggableFSM;

[CreateAssetMenu(menuName=Paths.connections + "test A")]
public class TestConnectionA : Connection
{
    public override bool Eval(Controller c)
    {
        CountTime();
        Debug.Log(name + " evaluating...");
        if (Input.GetKeyDown(KeyCode.A))
            return true;
        if (timeSpentEvaluating > 0.1f)
            return true;
        return false;
    }
}
