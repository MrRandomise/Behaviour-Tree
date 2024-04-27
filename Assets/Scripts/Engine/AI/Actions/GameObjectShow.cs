using System;
using AIModule;
using UnityEngine;

namespace Engine.AI.Actions
{
    [CreateAssetMenu(menuName = "SO/Create GameObjectShow", fileName = "GameObjectShow", order = 0)]
    public class GameObjectShow : AIAction
    {
        [SerializeField, BlackboardKey]
        private ushort _targetToShow;
        
        public override void Perform(IBlackboard blackboard)
        {
            if (!blackboard.TryGetObject(_targetToShow, out GameObject target))
                throw new NullReferenceException("Set target key");
            target.SetActive(true);
        }
    }
}