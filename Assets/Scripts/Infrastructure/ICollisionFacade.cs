using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingSim.Assets.Scripts.Infrastructure
{
    interface ICollisionFacade<T>
    {
        public T GetFacade();
    }
}
