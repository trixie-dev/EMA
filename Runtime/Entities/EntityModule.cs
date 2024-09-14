using System;
using UnityEngine.Events;

namespace EMA
{
    /// <summary>
    /// EntityComponent is a class used to create default components for entities.
    /// </summary>
    [Serializable]
    public abstract class EntityModule : IEntityModule
    {
        public IEntity Entity { get; set; }
        public bool Enabled { get; set; }
        public bool IsInitialized { get; set; }
        public UnityEvent OnInitialized { get; } = new();

        public virtual void Initialize(IEntity entity)
        {
            Entity = entity;
            Enabled = true;
        }

        public virtual void Update()
        {
        }

        protected void Initialized()
        {
            OnInitialized?.Invoke();
            IsInitialized = true;
        }
    }
}
