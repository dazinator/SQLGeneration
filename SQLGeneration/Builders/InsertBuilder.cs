using System;
using System.Collections.Generic;
using SQLGeneration.Parsing;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// Builds a string of an insert statement.
    /// </summary>
    public class InsertBuilder : IOutputCommand
    {
        private readonly AliasedSource _table;
        private readonly List<Column> _columns;
        private readonly List<Column> _outputColumns;
        private readonly IValueProvider _values;
        private bool _hasTerminator = false;

        /// <summary>
        /// Initializes a new instance of a InsertBuilder.
        /// </summary>
        /// <param name="table">The table being inserted into.</param>
        /// <param name="values">The values to insert into the table.</param>
        /// <param name="alias">The alias to use to refer to the table.</param>
        public InsertBuilder(Table table, IValueProvider values, string alias = null)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            _table = new AliasedSource(table, alias);
            _columns = new List<Column>();
            _outputColumns = new List<Column>();
            _values = values;
        }

        /// <summary>
        /// Gets the table that is being inserted into.
        /// </summary>
        public AliasedSource Table
        {
            get { return _table; }
        }

        /// <summary>
        /// Gets the columns being inserted into.
        /// </summary>
        public IEnumerable<Column> Columns
        {
            get { return _columns; }
        }

        /// <summary>
        /// Gets the output columns.
        /// </summary>
        public IEnumerable<Column> OutputColumns
        {
            get { return _outputColumns; }
        }

        /// <summary>
        /// Adds the column to the insert statement.
        /// </summary>
        /// <param name="column">The column to add.</param>
        public void AddColumn(Column column)
        {
            if (column == null)
            {
                throw new ArgumentNullException("column");
            }
            _columns.Add(column);
        }      

        /// <summary>
        /// Removes the column from the insert statement.
        /// </summary>
        /// <param name="column">The column to remove.</param>
        /// <returns>True if the column was removed; otherwise, false.</returns>
        public bool RemoveColumn(Column column)
        {
            if (column == null)
            {
                throw new ArgumentNullException("column");
            }
            return _columns.Remove(column);
        }

        /// <summary>
        /// Adds the column as an output column.
        /// </summary>
        /// <param name="column">The column to add.</param>
        public void AddOutputColumn(Column column)
        {
            if (column == null)
            {
                throw new ArgumentNullException("column");
            }
            _outputColumns.Add(column);
        }

        /// <summary>
        /// Removes the column from the output columns.
        /// </summary>
        /// <param name="column">The column to remove.</param>
        /// <returns>True if the column was removed; otherwise, false.</returns>
        public bool RemoveOutputColumn(Column column)
        {
            if (column == null)
            {
                throw new ArgumentNullException("column");
            }
            return _outputColumns.Remove(column);
        }

        /// <summary>
        /// Gets the list of values or select statement that populates the insert.
        /// </summary>
        public IValueProvider Values
        {
            get { return _values; }
        }

        /// <summary>
        /// Gets whether this command has a terminator.
        /// </summary>
        public bool HasTerminator
        {
            get
            {
                return _hasTerminator;
            }
            set
            {
                _hasTerminator = value;
            }
        }

        void IVisitableBuilder.Accept(BuilderVisitor visitor)
        {
            visitor.VisitInsert(this);
        }


    }
}
