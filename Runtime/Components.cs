using System.Collections.Generic;

namespace ECA
{
    /// <summary>
    /// Components is a class that stores, initializes, and updates all entity components.
    /// </summary>  
    public class Components
    {
        private List<IEntityComponent> _components = new List<IEntityComponent>();

        public Components Add<T>() where T : IEntityComponent, new()
        {
            var component = new T();
            _components.Add(component);
            return this;
        }

        public void Initialize(IEntity entity)
        {
            foreach (var component in _components)
            {
                component.Initialize(entity);
            }
        }

        public void Update()
        {
            foreach (var component in _components)
            {
                if (component.Enabled)
                {
                    component.Update();
                }
            }
        }

        public T GetSystem<T>() where T : IEntityComponent
        {
            foreach (var component in _components)
            {
                if (component is T)
                {
                    return (T)component;
                }
            }

            return default;
        }
    }
}