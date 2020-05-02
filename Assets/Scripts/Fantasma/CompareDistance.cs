namespace BehaviorDesigner.Runtime.Tasks.Unity.SharedVariables
{
    [TaskCategory("Unity/SharedVariable")]
    [TaskDescription("Returns success if the variable value is higher than the compareTo value.")]
    public class CompareDistance : Conditional
    {
        [Tooltip("The first variable to compare")]
        public SharedFloat variable;
        [Tooltip("The variable to compare to")]
        public float compareTo;

        public override TaskStatus OnUpdate()
        {
            float var = variable.Value;
            return var > compareTo ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnReset()
        {
            variable = 0;
            compareTo = 0;
        }
    }
}