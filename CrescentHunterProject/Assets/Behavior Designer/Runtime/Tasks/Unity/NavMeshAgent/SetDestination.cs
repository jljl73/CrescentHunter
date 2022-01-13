using UnityEngine;
using UnityEngine.AI;

namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityNavMeshAgent
{
    [TaskCategory("Unity/NavMeshAgent")]
    [TaskDescription("Sets the destination of the agent in world-space units. Returns Success if the destination is valid.")]
    public class SetDestination: Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [SharedRequired]
        [Tooltip("The NavMeshAgent destination")]
        public SharedVector3 destination;
        public SharedGameObject target;

        // cache the navmeshagent component
        private NavMeshAgent navMeshAgent;
        private GameObject prevGameObject;

        Animator animator;

        public override void OnStart()
        {
            var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject) {
                navMeshAgent = currentGameObject.GetComponent<NavMeshAgent>();
                prevGameObject = currentGameObject;
            }
            animator = GetComponent<Animator>();
            animator.SetBool("Move", true);
        }


        public override TaskStatus OnUpdate()
        {
            if (navMeshAgent == null) {
                Debug.LogWarning("NavMeshAgent is null");
                return TaskStatus.Failure;
            }

            destination.Value = target.Value.transform.position;

            return navMeshAgent.SetDestination(destination.Value) ? TaskStatus.Running : TaskStatus.Failure;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            destination = Vector3.zero;
        }

        public override void OnEnd()
        {
            navMeshAgent.SetDestination(transform.position);
            animator.SetBool("Move", false);
        }

    }
}