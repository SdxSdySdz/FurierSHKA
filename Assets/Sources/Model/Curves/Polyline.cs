using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Sources.Model
{
    public class Polyline : BasePolyline
    {
        public Polyline(IEnumerable<Vector> vertices) : base(vertices)
        {
        }

        protected override Vector[] ProcessVertices(IEnumerable<Vector> vertices)
        {
            return vertices.ToArray();
        }
    }
}
