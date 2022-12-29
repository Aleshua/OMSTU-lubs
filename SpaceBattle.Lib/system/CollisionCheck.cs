using Hwdtech;
using Hwdtech.Ioc;

namespace SpaceBattle.Lib {
    public class CollisionCheck : ICommand
    {
        private readonly IUObject uObject1, uObject2;
        public CollisionCheck(IUObject _uObject1, IUObject _uObject2)
        {
            this.uObject1 = _uObject1;
            this.uObject2 = _uObject2;
        }
        
        public void Execute()
        {   
            var dlist = IoC.Resolve<IEnumerable<int>>("Collision.GetDeltas", uObject1, uObject2);

            if (IoC.Resolve<bool>("Collision.CheckWithTree", dlist)) 
            {
                throw new Exception("Collision");
            }
        }
    }
}