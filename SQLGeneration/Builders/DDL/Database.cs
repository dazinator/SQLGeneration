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

   

  

   
}
