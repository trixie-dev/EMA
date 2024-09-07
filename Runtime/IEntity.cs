using UnityEngine;

namespace EMA
{
    public interface IEntity
    {
        public int EntityId { get; set; }
        public GameObject GameObject { get; set; }
        public Transform Transform { get; }
        public Modules Modules { get; set; }
        public void Initialize(int entityId);
        public void Update();
        public void SafeDestroy();
    }
}