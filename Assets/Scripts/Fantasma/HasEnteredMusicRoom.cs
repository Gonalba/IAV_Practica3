using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success when an object enters the music room")]
    [TaskCategory("Physics")]
    public class HasEnteredMusicRoom : Conditional
    {
        [Tooltip("The object that we are searching for")]
        public GameObject targetObject;

        [Tooltip("The tag of the GameObject to check for a trigger against")]
        public string tag = "";
        [Tooltip("The object that entered the trigger")]
        public SharedGameObject otherGameObject;


        private bool triggered = false;
        private bool target = false;

        /// <summary>
        /// Returns success if an object was found otherwise failure
        /// </summary>
        /// <returns></returns>
        public override TaskStatus OnUpdate()
        {
            if (target)
            {
                // Return success if target was found
                return TaskStatus.Failure;
            }
            // Target object is not within hearing so return failure
            return TaskStatus.Success;
        }

        public override void OnEnd()
        {
            triggered = false;
            target = false;
        }

        public override void OnReset()
        {
            triggered = false;
            target = false;
        }

        private bool checkSoundSource(GameObject other)
        {
            if (other.gameObject.Equals(targetObject))
            {
                return true;
            }
            else return false;
        }

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == tag)
            {
                otherGameObject.Value = other.gameObject;
                triggered = true;
                target = checkSoundSource(other.gameObject);
            }
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == tag && other is SphereCollider)
            {
                otherGameObject.Value = other.gameObject;
                triggered = true;
                target = true;
                other.gameObject.GetComponent<Instruments>().fixInstruments();
            }
        }
    }
}
