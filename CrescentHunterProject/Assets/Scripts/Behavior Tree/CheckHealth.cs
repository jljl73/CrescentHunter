using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckHealth : Conditional
{
    [SerializeField]
    SharedFloat Health;
    [SerializeField]
    float Threshold = 100.0f;
    [SerializeField]
    bool more;

    public override void OnAwake()
    {
        //Health.Value = GetComponent<Status>().Health;
    }

    public override TaskStatus OnUpdate()
	{
        if (more)
            return Health.Value > Threshold ? TaskStatus.Success : TaskStatus.Failure;
        else
            return Health.Value < Threshold ? TaskStatus.Success : TaskStatus.Failure;
    }
}