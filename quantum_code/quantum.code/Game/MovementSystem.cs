using Photon.Deterministic;
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
            Input input = default;
            if (f.Unsafe.TryGetPointer(filter.Entity, out PlayerLink* playerLink))
            {
                input = *f.GetPlayerInput(playerLink->Player);
            }

            filter.CharacterController->Move(f, filter.Entity, input.Direction.XOY);
        }

        public struct Filter
        {
            public EntityRef Entity;
            public CharacterController3D* CharacterController;
        }
    }
}
