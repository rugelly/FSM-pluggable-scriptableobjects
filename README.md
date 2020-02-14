# FSM pluggable scriptableobjects
 adapted from the unity tutorial
 https://learn.unity.com/tutorial/5c515373edbc2a001fd5c79d


Overall: Works mostly the same as Unity's tutorial above, currently is full of Debug.Log()'s so you can follow along with the excecution order.
But: <State> is ugly and <Controller> doesn't have full(or any, really) use of the stack


# How To Use: 
** there is some test actions/connections in there for ref if you want **
- RClick->Create->Pluggable FSM->State
- Create a script using namespace PluggableFSM
- For Actions inherit from Action, Connections inherit from Connection
- Add [CreateAssetMenu] above your new script class, use Paths.whatever for some static strings to make menuName="" filling out easier. See MenuNamePaths.cs for deets, should be self-explanitory.
- Once your custom Action/Connection is written + has [CreateAssetMenu] you can: RClick->Create->Pluggable FSM/Actions/*action name here*    .../Connections/*connection name here*
- Drag and drop these into states
- Drag your *initial* state into the last spot of the Controller.stack List. (really the list should only have a length of 1 to start)


# Some changes from unity's tut:
- Changed how transitions(I called them connections) work: you choose the result true/false you are looking for, and the active state will change when that is found.
- Connections also have a "how long have I been active" timer if you want: call CountTime() in Eval() and then check timeSpentEvaluating whenever.
- Actions + Connections have Enter()/Exit() calls you can use to init/set/reset variables or something.
- If you want to access <Controller> from a Enter()/Exit() and it's not already being passed through? You can pass it through in the foreach loops in <State>

# the controller stack
- **Operating Rule:** The state at the end of the list is the active state.
- Missing complete functionality because I dont need that for my use right now.
- Set the maxSize to something and you get a history of the states you have gone through. (will trim itself when exceeding the length)

- There is Pop() but it wont call Enter/Exit for the state currently. Ideally it removes the current state which makes the previous the new current state. <- would like to add this tbh
