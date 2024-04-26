using System;
using AIModule;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class BTNode_UnloadResources : BTNode
    {
        public override string Name => "Unload Resources";

        [SerializeField, BlackboardKey]
        private ushort character;

        [SerializeField, BlackboardKey]
        private ushort targetStorage;
        
        protected override BTState OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}