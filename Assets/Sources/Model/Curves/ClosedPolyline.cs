using System.Collections.Generic;
using System.Linq;

namespace Assets.Sources.Model
{
    public class ClosedPolyline : BasePolyline
    {
        public ClosedPolyline(IEnumerable<Vector> vertices) : base(vertices)
        {
        }

        protected override Vector[] ProcessVertices(IEnumerable<Vector> vertices)
        {
            int verticesCount = vertices.Count();
            Vector[] result = new Vector[verticesCount + 1];

            int i = 0;
            foreach (var vertex in vertices)
            {
                result[i] = vertex;
                i++;
            }

            result[verticesCount] = vertices.First();

            return result;
        }
    }
}
