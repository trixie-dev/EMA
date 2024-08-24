using UnityEngine;

namespace ECA
{
    public class Entity : MonoBehaviour, IEntity
    {
        public int EntityId { get; set; }
        public GameObject GameObject { get; set; }
        public Transform Transform => gameObject.transform;

        public Components Components { get; set; } = new Components();


        public virtual void Initialize(int entityId)
        {
            EntityId = entityId;
            GameObject = (this).gameObject;
        }

        public virtual void Update() => Components.Update();


        public virtual void SafeDestroy()
        {
            Destroy((this).gameObject);
        }
    }
}
