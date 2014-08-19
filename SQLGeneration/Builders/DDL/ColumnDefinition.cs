using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{

    /// <summary>
    /// The column definition list.
    /// </summary>
    public class ColumnDefinitionList : IEnumerable<ColumnDefinition>
    {
        private readonly List<ColumnDefinition> _columnDefinitions;

        /// <summary>
        /// Constructor.
        /// </summary>      
        public ColumnDefinitionList()
        {
            _columnDefinitions = new List<ColumnDefinition>();
        }

        /// <summary>
        /// Adds the column definition to the list.
        /// </summary>
        /// <param name="columnDefinition">The column definition to add.</param>
        public void AddColumnDefinition(ColumnDefinition columnDefinition)
        {
            if (columnDefinition == null)
            {
                throw new ArgumentNullException("columnDefinition");
            }
            _columnDefinitions.Add(columnDefinition);
        }

        /// <summary>
        /// Removes the column definiton from the list.
        /// </summary>
        /// <param name="columnDefinition">The column definiton to remove.</param>
        /// <returns>True if the column definiton was removed; otherwise, false.</returns>
        public bool RemoveColumnDefinition(ColumnDefinition columnDefinition)
        {
            if (columnDefinition == null)
            {
                throw new ArgumentNullException("columnDefinition");
            }
            return _columnDefinitions.Remove(columnDefinition);
        }

        /// <summary>
        /// Clears the column definitions.
        /// </summary>
        public void Clear()
        {
            _columnDefinitions.Clear();
        }

        /// <summary>
        /// Returns an enumerator that enumerates through the list of columns.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ColumnDefinition> GetEnumerator()
        {
            return _columnDefinitions.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _columnDefinitions.GetEnumerator();
        }
    }

    /// <summary>
    /// The column definition object.
    /// </summary>
    public class ColumnDefinition : IDatabaseObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        public ColumnDefinition(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The name of the column.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The collation of the column.
        /// </summary>
        public string Collation { get; set; }

        /// <summary>
        /// The datatype of the column.
        /// </summary>
        public DataType DataType { get; set; }

        /// <summary>
        /// The autoincrement of the column.
        /// </summary>
        public AutoIncrement AutoIncrement { get; set; }

        /// <summary>
        /// The default value of the column.
        /// </summary>
        public DefaultConstraint Default { get; set; }

        /// <summary>
        /// Whether the column can hold null values.
        /// </summary>
        public bool? IsNullable { get; set; }

        /// <summary>
        /// Whether the column is the primary key.
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        void IVisitableBuilder.Accept(BuilderVisitor visitor)
        {
            visitor.VisitColumnDefinition(this);
        }
    }
}
