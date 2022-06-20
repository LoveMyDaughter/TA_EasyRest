using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Tools.Find
{
    public interface ISearchStrategy : ISearch
    {
        void SetImplicitStrategy();

        void SetExplicitStrategy();
    }

}
