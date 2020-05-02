using UnityEngine;
using UnityEngine.AI;
namespace BehaviorDesigner.Runtime.Tasks
{

    public class Patrol : Conditional
    {
        public SharedGameObject[] nodes;

        private int currentNode;
        private NavMeshAgent navegador;
        bool start = false;

        // Update is called once per frame
        public override TaskStatus OnUpdate()
        {
            if (!start)
            {
                navegador = gameObject.GetComponent<NavMeshAgent>();
                currentNode = 0;
                navegador.SetDestination(nodes[currentNode].Value.transform.position);
                navegador.isStopped = false;
                start = true;
            }
            if (navegador.isStopped == true || navegador.remainingDistance < 1)
            {
                changeNode();
            }
            return TaskStatus.Success;
        }

        void changeNode()
        {
            Debug.Log("CAMBIO");
            currentNode++;
            if (currentNode > (nodes.Length - 1))
            {
                currentNode = 0;
            }

            navegador.SetDestination(nodes[currentNode].Value.transform.position);
            navegador.isStopped = false;
        }
    }
}
