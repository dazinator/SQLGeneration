using System;
using System.Collections.Generic;
using SQLGeneration.Parsing;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// Builds a string of a delete statement.
    /// </summary>
    public class DeleteBuilder : IFilteredCommand, IOutputCommand
    {
        private readonly AliasedSource _table;
        private readonly FilterGroup _where;
        private bool _hasTerminator = false;
        private readonly List<Column> _outputColumns;

        /// <summary>
        /// Initializes a new instance of a DeleteBuilder.
        /// </summary>
        /// <param name="table">The table being deleted from.</param>
        /// <param name="alias">The alias to use to refer to the table.</param>
        public DeleteBuilder(Table table, string alias = null)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }
            _table = new AliasedSource(table, alias);
            _where = new FilterGroup();
            _outputColumns = new List<Column>();
        }

        /// <summary>
        /// Gets the table being deleted from.
        /// </summary>
        public AliasedSource Table
        {
            get { return _table; }
        }

        /// <summary>
        /// Gets the filters in the where clause.
        /// </summary>
        public IEnumerable<IFilter> Where
        {
            get { return _where.Filters; }
        }

        /// <summary>
        /// Gets the filter group used to build the where clause.
        /// </summary>
        public FilterGroup WhereFilterGroup 
        {
            get { return _where; }
        }

        /// <summary>
        /// Adds the filter to the where clause.
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        public void AddWhere(IFilter filter)
        {
            _where.AddFilter(filter);
        }

        /// <summary>
        /// Removes the filter from the where clause.
        /// </summary>
        /// <param name="filter">The filter to remove.</param>
        /// <returns>True if the filter was removed; otherwise, false.</returns>
        public bool RemoveWhere(IFilter filter)
        {
            return _where.RemoveFilter(filter);
        }

        /// <summary>
        /// Gets the output columns.
        /// </summary>
        public IEnumerable<Column> OutputColumns
        {
            get { return _outputColumns; }
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
            visitor.VisitDelete(this);
        }
    }
}
