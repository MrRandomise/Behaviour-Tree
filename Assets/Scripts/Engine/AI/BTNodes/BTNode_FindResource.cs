using System;
using AIModule;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class BTNode_FindResource : BTNode
    {
        public override string Name => "Find Resource";

        [SerializeField, BlackboardKey]
        private ushort _character;

        [SerializeField, BlackboardKey]
        private ushort _resourceService;

        [SerializeField, BlackboardKey]
        private ushort _target;

        [SerializeField, BlackboardKey]
        private ushort _resource;
        
        protected override BTState OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            if (!blackboard.TryGetObject(_character, out IAtomicObject movingCharacter))
                return BTState.FAILURE;
            if(!blackboard.TryGetObject(_resourceService, out ResourceService resourceServiceValue))
                return BTState.FAILURE;
            
            var transform = movingCharacter.Get<Transform>(ObjectAPI.Transform);
            if (resourceServiceValue.FindClosestResource(transform.position, out IAtomicObject tree))
            {
                blackboard.SetObject(_target,tree);
                blackboard.SetObject(_resource,tree);
                return BTState.SUCCESS;
            }
            return BTState.FAILURE;
        }
    }
}