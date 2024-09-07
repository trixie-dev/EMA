using System.Collections.Generic;

namespace EMA
{
    /// <summary>
    /// Components is a class that stores, initializes, and updates all entity components.
    /// </summary>  
    public class Modules
    {
        private List<IEntityModule> _modules = new List<IEntityModule>();

        public Modules Add<T>() where T : IEntityModule, new()
        {
            var component = new T();
            _modules.Add(component);
            return this;
        }

        public void Initialize(IEntity entity)
        {
            foreach (var component in _modules)
            {
                component.Initialize(entity);
            }
        }

        public void Update()
        {
            foreach (var component in _modules)
            {
                if (component.Enabled)
                {
                    component.Update();
                }
            }
        }

        public T GetModule<T>() where T : IEntityModule
        {
            foreach (var component in _modules)
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