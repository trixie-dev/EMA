using UnityEngine;

namespace ECA
{
    public interface IEntity
    {
        public int EntityId { get; set; }
        public GameObject GameObject { get; set; }
        public Transform Transform { get; }
        public Components Components { get; set; }
        public void Initialize(int entityId);
        public void Update();
        public void SafeDestroy();
    }
}