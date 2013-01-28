﻿using System;
using SQLGeneration.Expressions;

namespace SQLGeneration
{
    /// <summary>
    /// Represents the addition of two items in a command.
    /// </summary>
    public class PlusExpression : ArithmeticExpression
    {
        /// <summary>
        /// Initializes a new instance of a PlusExpression.
        /// </summary>
        /// <param name="leftHand">The left hand side of the expression.</param>
        /// <param name="rightHand">The right hand side of the expression.</param>
        public PlusExpression(IProjectionItem leftHand, IProjectionItem rightHand)
            : base(leftHand, rightHand)
        {
        }

        /// <summary>
        /// Combines with the left hand operand with the right hand operand using the operation.
        /// </summary>
        /// <param name="options">The configuration to use when building the command.</param>
        /// <param name="leftHand">The left hand operand.</param>
        /// <param name="rightHand">The right hand operand.</param>
        /// <returns>The left and right hand operands combined using the operation.</returns>
        protected override IExpressionItem Combine(CommandOptions options, IExpressionItem leftHand, IExpressionItem rightHand)
        {
            // <Left> "+" <Right>
            Expression expression = new Expression();
            expression.AddItem(leftHand);
            expression.AddItem(new Token("+"));
            expression.AddItem(rightHand);
            return expression;
        }
    }
}
