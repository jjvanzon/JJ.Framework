using System.Collections.Generic;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Positioners
{
    /// <summary>
    /// <para>
    /// Base type for positioners. A positioner might calculate rectangle positions.
    /// Derived positioners might offer different types of positioning.
    /// </para>
    /// 
    /// <para>
    /// For instance: * distributing rectangles over a raster * flow positioning:
    /// where when no more items would fit on a row, the next item would continue on the next row.
    /// </para>
    /// 
    /// <para> If the calculation would need more input data,
    /// this might be passed along as constructor arguments or as properties perhaps. </para>
    /// </summary>
    public interface IPositioner
    {
        /// <summary>
        /// <para> Would return calculated rectangle positions as tuples. </para>
        ///
        /// <para> If the calculation would need more input data,
        /// this might be passed along as constructor arguments or as properties perhaps. </para>
        /// </summary>
        IList<(float x, float y, float width, float height)> Calculate();

        /// <summary>
        /// <para> Would assign calculated rectangle positions
        /// to the passed vector graphics elements. </para>
        ///
        /// <para> If the calculation would need more input data,
        /// this might be passed along as constructor arguments or as properties perhaps. </para>
        /// 
        /// <para> (Detail: The elements parameter would be enumerable for covariance, so a collection of e.g. Rectangles could also be passed to it.)</para>
        /// </summary>
        void Calculate(IEnumerable<Element> elements);
    }
}