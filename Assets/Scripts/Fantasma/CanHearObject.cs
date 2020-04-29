using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Tutorials
{
    [TaskCategory("Tutorial")]
    [TaskIcon("Assets/Behavior Designer Tutorials/Tasks/Editor/{SkinColor}CanSeeObjectIcon.png")]
    public class CanHearObject : Conditional
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
                return TaskStatus.Success;
            }
            // Target object is not within hearing so return failure
            return TaskStatus.Failure;
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

        private bool checkSoundSource (GameObject other)
        {
            if(other.gameObject.Equals(targetObject))
            {
                return true;
            }
            else return false;
        }

        void OnTriggerStay(Collider other)
        {
            Debug.Log(other.gameObject.tag);
            if (other.gameObject.tag == tag)
            {
                otherGameObject.Value = other.gameObject;
                triggered = true;
                target = checkSoundSource(other.gameObject);
            }
        }

        public override void OnTriggerEnter(Collider other)
        {
            Debug.Log("HAY TRIGGER");
            if (other.gameObject.tag == tag && other is BoxCollider)
            {
                otherGameObject.Value = other.gameObject;
                triggered = true;
                target = checkSoundSource(other.gameObject);
            }
        }
    }
}