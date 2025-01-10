using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Contracts
{
    public interface IWeapon
    {
        void Attack(ITarget target);
    }
}
