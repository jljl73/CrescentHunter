using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class SetTarget_Cond : Conditional
{
    public SharedTransform target = null;
    public SharedTransform returnTarget;
    public float ViewDistance = 10.0f;


    public override TaskStatus OnUpdate()
    {
        returnTarget.Value = WithinSight(target.Value) ?  target.Value : null;

        if (returnTarget.Value == null)
            return TaskStatus.Failure;

        return TaskStatus.Success;
    }

    bool WithinSight(Transform target)
    {
        return Vector3.Distance(target.position, transform.position) < ViewDistance;
    }

    
}
