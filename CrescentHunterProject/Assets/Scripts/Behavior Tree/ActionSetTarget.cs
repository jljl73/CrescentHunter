using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ActionSetTarget : Action
{
    [SerializeField]
    SharedTransform Target;

    public override void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        base.OnTriggerEnter(other);
        if (other.CompareTag("Player"))
            Target.Value = other.transform;
    }

    public override TaskStatus OnUpdate()
    {
        if (Target.Value == null)
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}