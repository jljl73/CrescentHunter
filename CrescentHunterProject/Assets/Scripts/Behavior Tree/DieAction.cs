using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class DieAction : Action
{
    [SerializeField]
    GameObject[] prevObjects;
	
    public override void OnEnd()
    {
        for (int i = prevObjects.Length - 1; i >= 0; --i)
            prevObjects[i].SetActive(false);
    }

    public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}