using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// Specifies any object that can be defined in the database and subjected to DDL statements such as "CREATE", "ALTER" and "DROP" statements.
    /// </summary>
    public interface IDatabaseObject : IVisitableBuilder
    {

    }

}
