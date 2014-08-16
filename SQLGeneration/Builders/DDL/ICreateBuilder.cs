using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// A builder specifying "CREATE" DDL statements.
    /// </summary>
    public interface ICreateBuilder : ICommand
    {
        /// <summary>
        /// The database object to be created.
        /// </summary>
        IDatabaseObject CreateObject { get; set; }
    }
}
