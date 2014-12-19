using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// Represents a SQL statement that has output columns.
    /// </summary>
    public interface IOutputCommand : ICommand
    {

        /// <summary>
        /// Adds the column as an output column.
        /// </summary>
        /// <param name="column">The column to add.</param>
        void AddOutputColumn(Column column);

        /// <summary>
        /// Removes the column from the output columns.
        /// </summary>
        /// <param name="column">The column to remove.</param>
        /// <returns>True if the column was removed; otherwise, false.</returns>
        bool RemoveOutputColumn(Column column);

    }
}
