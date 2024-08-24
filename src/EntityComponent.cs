using UnityEngine.Events;

namespace ECA
{
    /// <summary>
    /// EntityComponent is a class used to create default components for entities.
    /// </summary>  
    public abstract class EntityComponent : IEntityComponent
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
