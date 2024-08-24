namespace ECA.Examples
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
            Components
                .Add<EntityComponentExample>()
                .Add<EntityInput>()
                .Add<EntityMover>()
                .Initialize(this);
        
            // events 
            Components.GetSystem<EntityInput>().OnInputReceivedEvent += Components.GetSystem<EntityMover>().Move;
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

