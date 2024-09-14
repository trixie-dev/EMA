using System;
using System.Collections.Generic;

namespace EMA
{
    /// <summary>
    /// Components is a class that stores, initializes, and updates all entity components.
    /// </summary>
    [Serializable]
    public class ModulesManager
    {
        public List<IEntityModule> Modules = new List<IEntityModule>();

        public ModulesManager Add<T>() where T : IEntityModule, new()
        {
            var component = new T();
            Modules.Add(component);
            return this;
        }

        public void Initialize(IEntity entity)
        {
            foreach (var component in Modules)
            {
                component.Initialize(entity);
            }
        }

        public void Update()
        {
            foreach (var component in Modules)
            {
                if (component.Enabled)
                {
                    component.Update();
                }
            }
        }

        public T GetModule<T>() where T : IEntityModule
        {
            foreach (var component in Modules)
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