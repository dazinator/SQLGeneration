using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// Specifies any object that can be defined in the database that can be subjected to DDL statements such as "CREATE", "ALTER" and "DROP"
    /// </summary>
    public interface IDatabaseObject : IVisitableBuilder
    {

    }
}
