using System.Collections.Generic;
using UnityEngine;

namespace PluggableFSM
{
public class Controller : MonoBehaviour
{
    [SerializeField]
    private List<State> stack = new List<State>();
    public int current {get { return stack.Count - 1; } }
    public int currentTest;
    public int maxSize;
    
    [HideInInspector] public bool callEnterNextFrame;
    public State currentState {get { return stack[current]; } }

    [HideInInspector] public CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();

        callEnterNextFrame = true;
    }

    private void Update()
    {
        if (callEnterNextFrame)
        {
            currentState.Enter(this);
            callEnterNextFrame = false;
        }

        currentState.Tick(this);

        currentTest = current;
    }

    public void Pop()
    {
        if (stack.Count > 1)
            stack.RemoveAt(current);
    }

    // NOTE: 
    // make sure you call [controller.Add] instead of
    // calling [controller.stack.Add]
    public void Add(State s)
    {
        stack.Add(s);
        if (stack.Count > maxSize)
            stack.RemoveAt(0);
    }

    private void Trim()
    {
        if (stack.Count > maxSize)
            stack.RemoveAt(0);
    }
}
}