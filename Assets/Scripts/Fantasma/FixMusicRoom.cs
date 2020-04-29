using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success when MusicRoom is fixed")]
    [TaskCategory("Phantom")]
    public class FixMusicRoom : Conditional
    {

        private bool fixedRoom = false;
        public override TaskStatus OnUpdate()
        {
            return fixedRoom ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnEnd()
        {
            fixedRoom = false;
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Musica") && other is SphereCollider)
            {
                other.gameObject.GetComponent<Instruments>().fixInstruments();
                fixedRoom = true;
            }
        }

        public override void OnReset()
        {
            fixedRoom = false;
        }
    }
}