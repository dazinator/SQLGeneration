using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// A builder specifying "ALTER" DDL statements.
    /// </summary>
    public interface IAlterBuilder : ICommand
    {
        /// <summary>
        /// The database object to be altered.
        /// </summary>
        IDatabaseObject AlterObject { get; set; }
    }
}
