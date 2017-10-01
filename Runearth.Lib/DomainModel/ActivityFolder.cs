using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runearth.Lib.DomainModel
{
    public class ActivityFolder : ActivityFolderItem
    {
        public ActivityFolder(string name)
        {
            Name = name;
        }
        public List<ActivityFolderItem> Items { get; private set; } = new List<ActivityFolderItem>();
    }
}
