using SQLGeneration.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// The database object.
    /// </summary>
    public class Database : IDatabaseObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        public Database(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The name of the database.
        /// </summary>
        public string Name { get; set; }

        void IVisitableBuilder.Accept(BuilderVisitor visitor)
        {
            visitor.VisitDatabase(this);
        }
    }

    /// <summary>
    /// The table definition object.
    /// </summary>
    public class TableDefinition : IDatabaseObject
    {

        private readonly ColumnDefinitionList _columnDefinitionsList;

        /// <summary>
        /// Initializes a new instance of a Table.
        /// </summary>
        /// <param name="name">The name of the table.</param>
        public TableDefinition(string name)
            : this(null, name)
        {
        }

        /// <summary>
        /// Initializes a new instance of a Table.
        /// </summary>
        /// <param name="qualifier">The schema the table belongs to.</param>
        /// <param name="name">The name of the table.</param>
        public TableDefinition(Namespace qualifier, string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(Resources.BlankTableName, "name");
            }
            Qualifier = qualifier;
            Name = name;
            _columnDefinitionsList = new ColumnDefinitionList();
        }

        /// <summary>
        /// Gets or sets the schema the table belongs to.
        /// </summary>
        public Namespace Qualifier
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns the column definitions for the table.
        /// </summary>
        public ColumnDefinitionList Columns
        {
            get
            {
                return _columnDefinitionsList;
            }
        }

        void IVisitableBuilder.Accept(BuilderVisitor visitor)
        {
            visitor.VisitTableDefinition(this);
        }

    }

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
        /// The datatype of the column.
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Whether the column can hold null values.
        /// </summary>
        public bool IsNullable { get; set; }

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
