using System;
using AIModule;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class BTNode_MoveToTarget : BTNode
    {
        public override string Name => "Move To Target";

        [SerializeField, BlackboardKey]
        private ushort character;

        [SerializeField, BlackboardKey]
        private ushort target;

        [SerializeField, BlackboardKey]
        private ushort stoppingDistance;

        protected override BTState OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}