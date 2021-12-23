using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class Action_Chase : Action
{
    public float speed = 2.0f;
    public SharedTransform target;

    public override TaskStatus OnUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.Value.position - transform.position, Vector3.up).normalized, Time.deltaTime);

        if ((transform.position - target.Value.position).magnitude < 1.0f)
            return TaskStatus.Success;

        return TaskStatus.Running;
    }

}
