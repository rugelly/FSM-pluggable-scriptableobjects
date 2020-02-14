using UnityEngine;

namespace PluggableFSM
{
public abstract class Connection : ScriptableObject
{
    public abstract bool Eval(Controller controller);

    public float timeSpentEvaluating;

    public void CountTime()
    {
        timeSpentEvaluating += 1 * Time.deltaTime;
        timeSpentEvaluating = Mathf.Clamp(timeSpentEvaluating, 0, 999);
    }

    public void Enter()
    {
        Debug.Log(name + " connection enter");
        timeSpentEvaluating = 0;
    }
    
    public void Exit()
    {
        Debug.Log(name + " connection exit");
        timeSpentEvaluating = 0;
    }
}
}