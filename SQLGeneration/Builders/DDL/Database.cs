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
}
