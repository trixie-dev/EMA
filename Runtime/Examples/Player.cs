namespace EMA.Examples
{
    public class Player : Entity
    {
        public void Start()
        {
            Initialize(0);
        }

        public override void Initialize(int entityId)
        {
            base.Initialize(entityId);
            // component registration
            Modules
                .Add<EntityModuleExample>()
                .Add<EntityInput>()
                .Add<EntityMover>()
                .Initialize(this);
        
            // events 
            GetModule<EntityInput>().OnInputReceivedEvent += GetModule<EntityMover>().Move;
        }
    
        public override void Update()
        {
            base.Update();
            // additional update logic
        }

        public override void SafeDestroy()
        {
            // additional destroy logic
        
        
            // ------------------------
            base.SafeDestroy();
        }
    }
}

