using System.Collections.Generic;

namespace Runearth.Lib.DomainModel
{
    public class ActivityFolder : ActivityFolderItem
    {
        public ActivityFolder(string name)
        {
            Name = name;
        }

        public List<ActivityFolderItem> Items { get; private set; } = new List<ActivityFolderItem>();

        public void AddItem(ActivityFolderItem item)
        {
            Items.Add(item);
        }
    }
}