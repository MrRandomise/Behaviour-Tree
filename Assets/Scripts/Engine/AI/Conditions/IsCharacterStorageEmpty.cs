using System;
using AIModule;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    [CreateAssetMenu(menuName = "SO/Create IsCharacterStorageEmpty", fileName = "IsCharacterStorageEmpty", order = 0)]
    [System.Serializable]
    public class IsCharacterStorageEmpty : AICondition
    {
        [SerializeField, BlackboardKey]
        private ushort _character;
        
        public override bool Check(IBlackboard blackboard)
        {
            if (!blackboard.TryGetObject(_character, out IAtomicObject aiCharacter))
                throw new NullReferenceException("Set character key");
            var resourceStorage = aiCharacter.Get<ResourceStorage>(ObjectAPI.ResourceStorage);
            return resourceStorage.IsEmpty();
        }
    }
}