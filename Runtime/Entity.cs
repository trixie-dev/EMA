using UnityEngine;

namespace EMA
{
    public class Entity : MonoBehaviour, IEntity
    {
        public int EntityId { get; set; }
        public GameObject GameObject { get; set; }
        public Transform Transform => gameObject.transform;

        public Modules Modules { get; set; } = new Modules();


        public virtual void Initialize(int entityId)
        {
            EntityId = entityId;
            GameObject = (this).gameObject;
        }

        public virtual void Update() => Modules.Update();
        
        public T GetModule<T>() where T : IEntityModule
        {
            return Modules.GetModule<T>();
        }

        public virtual void SafeDestroy()
        {
            Destroy((this).gameObject);
        }
    }
}
