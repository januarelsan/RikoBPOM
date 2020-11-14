using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State{
        Idle,
        Run,
        Jump,
        Slide,
        Push,
        Dash,
        Hurt,
        Toss,
        Attack,
        Die
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Run;    
    }

    void Update(){
        // Debug.Log("Main State: " + state.ToString());
    }

    public State GetState(){
        return state;
    }
  
    public void SwitchState(string name){
        
        state = (State) State.Parse(typeof(State), name);        
        GetComponent<Animator>().SetTrigger(name);

        // Debug.Log("Change State to: " + state.ToString());
    }

    
}
