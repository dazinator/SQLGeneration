using SQLGeneration.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// The alter table definition builder.
    /// </summary>
    public class AlterTableDefinition : IDatabaseObject
    {

        private readonly ColumnDefinitionList _addColumnsList;

        /// <summary>
        /// Initializes a new instance of a Table.
        /// </summary>
        /// <param name="name">The name of the table.</param>
        public AlterTableDefinition(string name)
            : this(null, name)
        {
        }

        /// <summary>
        /// Initializes a new instance of a Table.
        /// </summary>
        /// <param name="qualifier">The schema the table belongs to.</param>
        /// <param name="name">The name of the table.</param>
        public AlterTableDefinition(Namespace qualifier, string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(Resources.BlankTableName, "name");
            }
            Qualifier = qualifier;
            Name = name;
            _addColumnsList = new ColumnDefinitionList();
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
        /// Returns the columns to be added.
        /// </summary>
        public ColumnDefinitionList AddColumns
        {
            get
            {
                return _addColumnsList;
            }
        }

        /// <summary>
        /// The alteration to an existing column.
        /// </summary>
        public IAlterColumn AlterColumn { get; set; }

        void IVisitableBuilder.Accept(BuilderVisitor visitor)
        {
            visitor.VisitAlterTableDefinition(this);
        }

    }

}
