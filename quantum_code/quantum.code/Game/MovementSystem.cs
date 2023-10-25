using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Game
{
    public unsafe class MovementSystem : SystemMainThreadFilter<MovementSystem.Filter>
    {
        public override void Update(Frame f, ref Filter filter)
        {
            var input = *f.GetPlayerInput(0);

            filter.CharacterController->Move(f, filter.Entity, input.Direction.XOY);
        }

        public struct Filter
        {
            public EntityRef Entity;
            public CharacterController3D* CharacterController;
        }
    }
}
