using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBehaviour : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("Dead", true);
        animator.SetBool("Movable", false);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("Dead", false);
    }
}
