using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    [SerializeField]
    float StaminaUsage = 5.0f;
    Status status = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("Left Attack", false);
        animator.SetBool("Right Attack", false);
        animator.SetBool("Movable", false);

        if (status == null)
            status = animator.GetComponent<Status>();
        status.AddStamina(-StaminaUsage);

        if (status.Stamina == 0.0f)
            animator.SetBool("EmptyStamina", true);
        else
            animator.SetBool("EmptyStamina", false);
    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("Left Attack", false);
        animator.SetBool("Right Attack", false);
    }
}
