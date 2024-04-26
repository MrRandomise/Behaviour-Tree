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
        private ushort character;

        [SerializeField, BlackboardKey]
        private ushort resourceService;

        [SerializeField, BlackboardKey]
        private ushort targetResource;

        protected override BTState OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}