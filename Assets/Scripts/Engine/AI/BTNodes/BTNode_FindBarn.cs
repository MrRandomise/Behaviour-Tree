using AIModule;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    public class BTNode_FindBarn: BTNode
    {
        public override string Name => "Find Barn";

        [SerializeField, BlackboardKey]
        private ushort _character;

        [SerializeField, BlackboardKey]
        private ushort _barn;

        [SerializeField, BlackboardKey]
        private ushort _target;
        
        protected override BTState OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            if (!blackboard.TryGetObject(_character, out IAtomicObject movingCharacter))
                return BTState.FAILURE;
            if(!blackboard.TryGetObject(_barn, out IAtomicObject barnValue))
                return BTState.FAILURE;
            
            blackboard.SetObject(_target,barnValue);
            return BTState.SUCCESS;
        }
    }
}