using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class LoadingList
    {
        public String LoadingListId { get; set; }
        public String Comment { get; set; }
        public Int32 Year { get; set; }
        public String DepartmentId { get; set; }


        public virtual Department Department { get; set; }
        public virtual ICollection<DayEntryLoad> DayEntryLoads { get; set; }
        public virtual ICollection<ExtramuralEntryLoad> ExtramuralEntryLoads { get; set; }
        public virtual ICollection<DDataStorage> DDataStorages { get; set; }
        public virtual ICollection<EDataStorage> EDataStorages { get; set; }
    }
}
