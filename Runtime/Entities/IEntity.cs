using UnityEngine;

namespace EMA
{
    public interface IEntity
    {
        public int EntityId { get; set; }
        public bool IsInitialized { get; set; }
        public GameObject GameObject { get; set; }
        public Transform Transform { get; }
        public ModulesManager ModulesManager { get; set; }
        public void Initialize(int entityId);
        public void Initialized();
        public void Update();
        public void SafeDestroy();
    }
}