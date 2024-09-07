using EMA;

public class ${CLASS} : Entity
{
    public override void Initialize(int entityId)
    {
        base.Initialize(entityId);
        
        // component registration
        //Components
        //        .Add<EntityComponentExample>()
        //        .Initialize(this);
        
        // events 
        
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
