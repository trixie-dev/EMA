using UnityEngine;

namespace EMA.Examples
{
    public class EntityInput : EntityModule
    {
        public float HorizontalInputTest { get; private set; }
        public float VerticalInput { get; private set; }

        public delegate void OnInputReceived(Vector2 direction);

        public OnInputReceived OnInputReceivedEvent;

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);
            Debug.Log("EntityInput initialized");
            Initialized();
        }

        public override void Update()
        {
            float horizontal;
            float vertical;

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            HorizontalInputTest = horizontal;
            VerticalInput = vertical;

            Vector2 direction = new Vector2(horizontal, vertical).normalized;
            OnInputReceivedEvent?.Invoke(direction);
            Debug.Log($"EntityInput updated: {direction}");
        }


    }
}
