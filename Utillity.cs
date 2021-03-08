using System;
using System.Collections.Generic;

namespace HouseHashing
{
    public class Utillity
    {
        public static Tuple<T1, T2> CloneAndModify<T1, T2>(Tuple<T1, T2> original, T1 item1, T2 item2)
        {
            return Tuple.Create(item1 == null ? original.Item1 : item1, item2 == null ? original.Item2 : item2);
        }
    }
}