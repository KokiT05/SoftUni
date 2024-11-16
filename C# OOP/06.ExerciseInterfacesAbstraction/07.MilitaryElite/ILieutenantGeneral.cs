using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyList<IPrivate> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}
