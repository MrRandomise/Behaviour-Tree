using System;
using AIModule;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class BTNode_ExtractResource : BTNode
    {
        public override string Name => "Extract Resource";

        [SerializeField, BlackboardKey]
        private ushort _character;
        
        [SerializeField, BlackboardKey]
        private ushort _resource;

        [SerializeField, BlackboardKey]
        private ushort _minDistance;

        protected override BTState OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            if (!blackboard.TryGetObject(_character, out IAtomicObject aiCharacter))
                return BTState.FAILURE;
            if(!blackboard.TryGetObject(_resource, out IAtomicObject resourceObject))
                return BTState.FAILURE;
            if (!blackboard.TryGetFloat(_minDistance, out float distance))
                return BTState.FAILURE;

            var aiStorage = aiCharacter.Get<ResourceStorage>(ObjectAPI.ResourceStorage);
            if (aiStorage.IsFull())
                return BTState.SUCCESS;
            
            var treeResourceStorage = resourceObject.Get<ResourceStorage>(ObjectAPI.ResourceStorage);
            if (treeResourceStorage.IsEmpty())
                return BTState.SUCCESS;
            
            var isGathering = aiCharacter.GetValue<bool>(ObjectAPI.IsGathering);
            if (isGathering.Value)
                return BTState.RUNNING;
            
            var transform = aiCharacter.Get<Transform>(ObjectAPI.Transform);
            var resourceTransform = resourceObject.Get<Transform>(ObjectAPI.Transform);

            var targetDirection = (resourceTransform.position-transform.position);

            if (Vector3.SqrMagnitude(targetDirection) > distance * distance)
            {
                return BTState.FAILURE;
            }
            
            aiCharacter.InvokeAction(ObjectAPI.GatherRequest);
            
            return BTState.RUNNING;
        }
    }
}