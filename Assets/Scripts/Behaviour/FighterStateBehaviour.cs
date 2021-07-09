using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStateBehaviour : StateMachineBehaviour
{
    public FighterState behaviorState;
    public float horizontalForce;
    public float verticalForce;
    protected Fighter fighter; 

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(fighter == null)
        {
            fighter = animator.gameObject.GetComponent<Fighter>();
        }
        // the below one is for when Voltrobe dies not for jump
        fighter.currentState = behaviorState;
        fighter.body.AddRelativeForce(new Vector3(0, verticalForce, 0));
        
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fighter.body.AddForce(new Vector3(-horizontalForce, 0, 0));

    }
}
