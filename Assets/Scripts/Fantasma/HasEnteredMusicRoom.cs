using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success when an object enters the music room")]
    [TaskCategory("Physics")]
    public class HasEnteredMusicRoom : Conditional
    {

        private bool enteredTrigger = false;

        public override TaskStatus OnUpdate()
        {
            return enteredTrigger ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnEnd()
        {
            enteredTrigger = false;
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Musica") && other is SphereCollider)
            {
                enteredTrigger = true;
            }
        }

        public override void OnReset()
        {
            enteredTrigger = false;
        }
    }
}
