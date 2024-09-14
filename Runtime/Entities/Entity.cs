using System;
using UnityEngine;

namespace EMA
{
    
    [Serializable]
    public class Entity : MonoBehaviour, IEntity
    {
        public int EntityId { get; set; }
        public bool IsInitialized { get; set; }
        public GameObject GameObject { get; set; }
        public Transform Transform => gameObject.transform;

        public ModulesManager ModulesManager { get; set; } = new ModulesManager();


        public virtual void Initialize(int entityId)
        {
            EntityId = entityId;
            GameObject = (this).gameObject;
        }
        
        public virtual void Initialized()
        {
            IsInitialized = true;
        }

        public virtual void Update() => ModulesManager.Update();
        
        public T GetModule<T>() where T : IEntityModule
        {
            return ModulesManager.GetModule<T>();
        }

        public virtual void SafeDestroy()
        {
            ModulesManager.Modules.Clear();
            if (this.gameObject != null)
                Destroy((this).gameObject);
        }
    }
}
