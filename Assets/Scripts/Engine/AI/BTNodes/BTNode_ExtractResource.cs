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
        private ushort character;
        
        [SerializeField, BlackboardKey]
        private ushort resource;

        [SerializeField, BlackboardKey]
        private ushort minDistance;

        protected override BTState OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}