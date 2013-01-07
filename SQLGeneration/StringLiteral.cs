﻿using System;
using System.Text;

namespace SQLGeneration
{
    /// <summary>
    /// Represents a literal string.
    /// </summary>
    public class StringLiteral : ILiteral
    {
        private string _value;
        private string _alias;

        /// <summary>
        /// Creates a new StringLiteral.
        /// </summary>
        public StringLiteral()
        {
            _value = String.Empty;
        }

        /// <summary>
        /// Creates a new StringLiteral.
        /// </summary>
        /// <param name="value">The string value.</param>
        public StringLiteral(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets or sets the value of the string literal.
        /// </summary>
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Gets or sets an alias for the string.
        /// </summary>
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                _alias = value;
            }
        }

        string IProjectionItem.GetFullText()
        {
            return getText();
        }

        string IFilterItem.GetFilterItemText()
        {
            return getText();
        }

        string IGroupByItem.GetGroupByItemText()
        {
            return getText();
        }

        private string getText()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("'");
            if (_value != null)
            {
                // escape quotes
                builder.Append(_value.Replace("'", "''"));
            }
            builder.Append("'");
            return builder.ToString();
        }
    }
}
