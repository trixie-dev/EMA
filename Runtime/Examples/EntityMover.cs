using UnityEngine;

namespace ECA.Examples
{
    public class EntityMover : EntityComponent
    {
        private float _speed = 5f;
        private Vector2 _desiredDirection;

        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);
            // component initialization here
            Initialized();
        }

        public override void Update()
        {
            // component update here
            Entity.Transform.Translate(_desiredDirection * (_speed * Time.deltaTime));
        }

        public void Move(Vector2 direction)
        {
            _desiredDirection = direction;
        }


    }
}