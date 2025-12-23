using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Utils
{
    public class CamelCaseSerializerStrategy : PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            return char.ToLowerInvariant(clrPropertyName[0]) + clrPropertyName.Substring(1);
        }
    }
}
