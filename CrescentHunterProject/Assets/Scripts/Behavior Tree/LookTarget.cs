using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class LookTarget : Action
{
    [SerializeField]
    SharedTransform target;
    [SerializeField]
    float Angle = 20.0f;
    [SerializeField]
    float RotSpeed = 3.0f;

    Animator animator;

    public override void OnAwake()
    {
        animator = GetComponent<Animator>();
    }

    public override void OnStart()
    {
        animator.SetBool("Move", true);
    }

    public override void OnEnd()
    {
        animator.SetBool("Move", false);
    }

    public override TaskStatus OnUpdate()
	{
        if (target == null) return TaskStatus.Failure;

        Vector3 forward = transform.rotation * Vector3.forward;
        Vector3 dir = (target.Value.position - transform.position).normalized;
        float angle = Mathf.Acos(Vector3.Dot(forward, dir)) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(target.Value.position - transform.position, Vector3.up).normalized, Time.deltaTime * RotSpeed);

        
        if (Mathf.Abs(angle) < Angle)
            return TaskStatus.Success;
        else
            return TaskStatus.Running;
    }
}