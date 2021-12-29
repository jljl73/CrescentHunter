using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckDistance : Conditional
{
    [SerializeField]
    SharedTransform target;
    [SerializeField]
    float Distance = 1.0f;
    [SerializeField]
    bool more = false;
    [SerializeField]
    float dist = 0;

    public override TaskStatus OnUpdate()
	{
        dist = (target.Value.position - transform.position).magnitude;

        if(more)
            return dist > Distance ? TaskStatus.Success : TaskStatus.Failure;
        else
            return dist < Distance ? TaskStatus.Success : TaskStatus.Failure;
    }

}