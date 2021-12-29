using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class Action_Chase : Action
{
    public float speed = 2.0f;
    public float StopDisatance = 1.0f;
    public SharedTransform target;
    Animator animator;

    public override void OnStart()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Move", true);
    }

    public override TaskStatus OnUpdate()
    {
        if (target.Value == null)
            return TaskStatus.Failure;

        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.Value.position - transform.position, Vector3.up).normalized, Time.deltaTime);

        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        animator.SetBool("Move", false);
    }
}
