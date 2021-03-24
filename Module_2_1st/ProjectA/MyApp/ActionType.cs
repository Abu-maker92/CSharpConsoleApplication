using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.MyApp
{
    public enum Packages
    {
        Restaurant = 1, FishMarked, FruitMarked
    }
    public enum ActionType
    {
        ShowAllData = 1,
        SearchByID,
        SearchByName,
        AddNewItem,
        UpdateByID,
        DeleteByID,
        AboutThisProject,
        DevelopedBy
    }
}
