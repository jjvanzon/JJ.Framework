﻿using System;
using System.Collections.Generic;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Positioners
{
    /// <inheritdoc cref="IPositioner" />
    public abstract class PositionerBase : IPositioner
    {
        /// <inheritdoc />
        public abstract IList<(float x, float y, float width, float height)> Calculate();
        
        /// <inheritdoc />
        public void Calculate(IEnumerable<Element> elements)
        {
            if (elements == null) throw new ArgumentNullException(nameof(elements));

            IList<(float x, float y, float width, float height)> tuples = Calculate();

            var i = 0;
            foreach (Element element in elements)
            {
                ElementPosition elementPosition = element.Position;

                // Slight chance of invalid array index error, 
                // but better count checking is not worth
                // converting elements.ToArray.
                (elementPosition.X, elementPosition.Y, elementPosition.Width, elementPosition.Height) = tuples[i];

                i++;
            }
        }
    }
}
