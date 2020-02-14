using UnityEngine;

namespace PluggableFSM
{
[CreateAssetMenu(menuName=Paths.state)]
public class State : ScriptableObject
{
    public Action[] actions;
    public Connector[] connectors;

    public bool exiting;

    public void Enter(Controller controller) 
    {
        exiting = false;

        Debug.Log(name + " ENTERING ----------------------------------------------------");

        foreach (var connector in connectors)
        {
            connector.connection.Enter();
        }

        foreach (var action in actions)
        {
            action.Enter(controller);
        }
    }

    public void Tick(Controller controller) 
    {
        if (!exiting)
        {
            Debug.Log(name + " evaluating connections...");
            foreach (var connector in connectors)
            {
                var result = connector.connection.Eval(controller);

                if (connector.wantedResult == Connector.WantedResult.isTrue)
                    if (result)
                        Transition(controller, connector, result);

                if (connector.wantedResult == Connector.WantedResult.isFalse)
                    if (!result)
                        Transition(controller, connector, result);
                
                break;
            }
        }

        if (!exiting)
        {
            foreach (var action in actions)
            {
                action.Tick(controller);
            }
        }
    }

    private void Transition(Controller c, Connector connector, bool result)
    {
        Debug.Log(connector.connection.name + " the wanted result == " + result + "!");
        exiting = true;
        Exit();
        c.Add(connector.next);
        c.callEnterNextFrame = true;
    }

    public void Exit() 
    {
        Debug.Log(name + " EXITING ----------------------------------------------------");

        foreach (var connector in connectors)
        {
            connector.connection.Exit();
        }

        foreach (var action in actions)
        {
            action.Exit();
        }
    }
}
}