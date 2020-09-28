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
        Toss 
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;    
    }

    public State GetState(){
        return state;
    }

    public void SwitchState(int index){
        state = (State) index;
    }

    public void SwitchState(string name){
        if(name != "Default")
            state = (State) State.Parse(typeof(State), name);        
        else
            state = State.Run;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
