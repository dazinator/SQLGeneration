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
    /// The Constraint List.
    /// </summary>
    public class ConstraintList : IEnumerable<Constraint>
    {
        private readonly List<Constraint> _columnConstraints;

        /// <summary>
        /// Constructor.
        /// </summary>      
        public ConstraintList()
        {
            _columnConstraints = new List<Constraint>();
        }

        /// <summary>
        /// Adds the constraint to the list.
        /// </summary>
        /// <param name="constraint">The constraint to add.</param>
        public void AddConstraint(Constraint constraint)
        {
            if (constraint == null)
            {
                throw new ArgumentNullException("constraint");
            }
            _columnConstraints.Add(constraint);
        }

        /// <summary>
        /// Removes the constraint from the list.
        /// </summary>
        /// <param name="constraint">The constraint to remove.</param>
        /// <returns>True if the constraint was removed; otherwise, false.</returns>
        public bool RemoveConstraint(Constraint constraint)
        {
            if (constraint == null)
            {
                throw new ArgumentNullException("constraint");
            }
            return _columnConstraints.Remove(constraint);
        }

        /// <summary>
        /// Clears the constraint.
        /// </summary>
        public void Clear()
        {
            _columnConstraints.Clear();
        }

        /// <summary>
        /// Returns an enumerator that enumerates through the list of constraints.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Constraint> GetEnumerator()
        {
            return _columnConstraints.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _columnConstraints.GetEnumerator();
        }
    }
}
