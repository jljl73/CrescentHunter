using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckHealth : Conditional
{
    [SerializeField]
    SharedInt Health;
    [SerializeField]
    int Threshold = 100;
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