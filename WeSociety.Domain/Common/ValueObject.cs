using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Domain.Common
{
    public abstract class ValueObject
    {
        public abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if(obj is null || obj.GetType() != GetType()) return false;
            var valObj = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(valObj.GetEqualityComponents());
        }
    }
}
