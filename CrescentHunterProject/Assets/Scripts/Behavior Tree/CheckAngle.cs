using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckAngle : Conditional
{
    [SerializeField]
    SharedTransform target;
    [SerializeField]
    float Angle = 30.0f;

    public override TaskStatus OnUpdate()
    {
        Vector3 dir = (target.Value.position - transform.position);
        float angle =  Vector3.Angle(dir, Vector3.forward);

        if (Mathf.Abs(angle) < Angle)
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}