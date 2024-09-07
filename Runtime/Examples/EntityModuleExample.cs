namespace EMA.Examples
{
    public class EntityModuleExample : EntityModule
    {
        public override void Initialize(IEntity entity)
        {
            base.Initialize(entity);
            // component initialization here
            Initialized();
        }

        public override void Update()
        {
            // component update here
        }
    }
}