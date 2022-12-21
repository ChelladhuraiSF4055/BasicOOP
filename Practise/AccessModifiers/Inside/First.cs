using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inside
{
    public class First:Third
    {
        public int PublicNumber=10;

        private int PrivateNumber=12;
        public int PrivateOut{get{return PrivateNumber;}}
         

        internal int InternalNumber=13;
        protected int ProtectedNumber=40;
        public  int ProtectedLevel{get{return ProtectedNumber;}}

        //public int ProtectedInternalLevel{get{return ProtectedInternal}}
    }
}