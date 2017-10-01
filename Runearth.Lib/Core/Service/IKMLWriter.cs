using Runearth.Lib.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runearth.Lib.Core.Service
{
    public interface IKmlWriter
    {
        void Write(string filename, ActivityFolder folder);
    }
}
