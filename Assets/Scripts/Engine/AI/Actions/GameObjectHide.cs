using System;
using AIModule;
using Game.Engine;
using UnityEngine;

namespace Engine.AI.Actions
{
    [CreateAssetMenu(menuName = "SO/Create GameObjectHide", fileName = "GameObjectHide", order = 0)]
    public class GameObjectHide : AIAction
    {
        [SerializeField, BlackboardKey]
        private ushort _targetToHide;
        
        public override void Perform(IBlackboard blackboard)
        {
            if (!blackboard.TryGetObject(_targetToHide, out GameObject target))
                throw new NullReferenceException("Set target key");
            target.SetActive(false);
        }
    }
}