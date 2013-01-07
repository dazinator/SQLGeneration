﻿using System;

namespace SQLGeneration
{
    /// <summary>
    /// Generates the intersection among all of the queries.
    /// </summary>
    public class Intersect : SelectCombiner
    {
        /// <summary>
        /// Creates a new Intersect.
        /// </summary>
        public Intersect()
        {
        }

        /// <summary>
        /// Retrieves the text used to combine two queries.
        /// </summary>
        /// <returns>The text used to combine two queries.</returns>
        protected override string GetCombinationString()
        {
            return "INTERSECT";
        }
    }
}
