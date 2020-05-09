using System;
using System.Collections.Generic;
using System.Text;

namespace Dietation_Test
{
    class CompareListsSearching
    {
        //first parameter filter list second parameter user ingredient list
        //list of strings datatype
        public bool Compare(List<string> filter, List<string> ingredients)
        {
            for(int i = 0; i < filter.Count; i++)
            {
                if (ingredients.Contains(filter[i]))
                    return false;
            }

            return true;
        }
    }
}
