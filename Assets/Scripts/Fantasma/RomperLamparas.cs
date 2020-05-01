using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
namespace BehaviorDesigner.Runtime.Tasks
{
    public class RomperLamparas : Conditional
    {
        public SharedTransform palancaE;
        public SharedTransform palancaO;

        public override TaskStatus OnUpdate()
        {
            if ((palancaO.Value.position.x == transform.position.x && palancaO.Value.position.z == transform.position.z) ||
                (palancaE.Value.position.x == transform.position.x && palancaE.Value.position.z == transform.position.z))
                return TaskStatus.Success;
            return TaskStatus.Failure;
        }
    }
}