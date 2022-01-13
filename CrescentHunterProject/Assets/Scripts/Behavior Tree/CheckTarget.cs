using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckTarget : Conditional
{
    [SerializeField]
    SharedGameObject Target;

    [SerializeField]
    bool Reverse;

	public override TaskStatus OnUpdate()
	{
        
        if (Target.Value == null)
            return Reverse ? TaskStatus.Success : TaskStatus.Failure;
        else
		    return Reverse ? TaskStatus.Failure : TaskStatus.Success;
	}

}