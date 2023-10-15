using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleStateBlock : StateMachineBehaviour
{
    public string stateName;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName(stateName))
            Debug.Log(stateName + ": enter");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName(stateName))
            Debug.Log(stateName + ": update");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName(stateName))
        {
            Debug.Log(stateName + ": update");
            Debug.Log("gameObject: " + animator.gameObject.name);
        }
    }
}
