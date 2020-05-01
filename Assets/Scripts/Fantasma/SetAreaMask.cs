using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class SetAreaMask : Conditional
{
    public SharedBool statePublico;
    public SharedGameObject fantasma;
    int maskConEscenario;
    int maskSinEscenario;
    public override void OnStart()
    {
    }
    public override TaskStatus OnUpdate()
    {
        int areaEscanerio = NavMesh.GetAreaFromName("Escenario");
        int areaCantante = NavMesh.GetAreaFromName("Cantante");
        int areaNotWalKable = NavMesh.GetAreaFromName("Not Walkable");

        if (statePublico.Value)
        {
            fantasma.Value.GetComponent<NavMeshAgent>().areaMask = 13;
            return TaskStatus.Success;
        }
        else
        {
            fantasma.Value.GetComponent<NavMeshAgent>().areaMask = 45;
            return TaskStatus.Failure;
        }
    }
}
