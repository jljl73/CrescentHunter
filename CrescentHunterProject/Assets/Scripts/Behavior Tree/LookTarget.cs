using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class LookTarget : Action
{
    public SharedTransform target = null;
    [SerializeField]
    float RotSpeed = 3.0f;
    
	public override TaskStatus OnUpdate()
	{
        if (target == null) return TaskStatus.Failure;

        transform.rotation = Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(target.Value.position - transform.position, Vector3.up).normalized, Time.deltaTime * RotSpeed);

        return TaskStatus.Running;
	}
}