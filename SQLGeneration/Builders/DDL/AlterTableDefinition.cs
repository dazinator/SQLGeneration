using SQLGeneration.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// Defines any object that represents an alter to a column.
    /// </summary>
    public interface IAlterColumn : IVisitableBuilder
    {
        

    }


    /// <summary>
    /// The alter table definition object.
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

    /// <summary>
    /// An alter column that adds a column property.
    /// </summary>
    public class AlterColumnAddProperty : IAlterColumn
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        public AlterColumnAddProperty(string name)
        {
            this.PropertyName = name;
        }

        /// <summary>
        /// The name of the column.
        /// </summary>
        public string PropertyName { get; set; }

        void IVisitableBuilder.Accept(BuilderVisitor visitor)
        {
            visitor.VisitAlterColumnAddProperty(this);
        }

    }

    /// <summary>
    /// An alter column that drops a column property.
    /// </summary>
    public class AlterColumnDropProperty : IAlterColumn
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        public AlterColumnDropProperty(string name)
        {
            this.PropertyName = name;
        }

        /// <summary>
        /// The name of the column.
        /// </summary>
        public string PropertyName { get; set; }

        void IVisitableBuilder.Accept(BuilderVisitor visitor)
        {
            visitor.VisitAlterColumnDropProperty(this);
        }

    }

    /// <summary>
    /// An alter column.
    /// </summary>
    public class AlterColumn : IAlterColumn
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        public AlterColumn(string name)
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
        /// Whether the column can hold null values.
        /// </summary>
        public bool? IsNullable { get; set; }

        void IVisitableBuilder.Accept(BuilderVisitor visitor)
        {
            visitor.VisitAlterColumn(this);
        }

    }
}
