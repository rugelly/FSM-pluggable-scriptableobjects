using UnityEngine;
using PluggableFSM;

[CreateAssetMenu(menuName=Paths.connections + "test B")]
public class TestConnectionB : Connection
{
    public override bool Eval(Controller c)
    {
        CountTime();
        Debug.Log(name + " evaluating...");
        if (Input.GetKeyDown(KeyCode.B))
            return true;
        if (timeSpentEvaluating > 0.2f)
            return true;
        return false;
    }
}
