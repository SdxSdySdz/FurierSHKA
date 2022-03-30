using System;

namespace Assets.Sources.Model
{
    public abstract class Transformable
    {
        public Vector Position { get; private set; }

        public event Action Moved;
        public event Action Destroying;

        public void MoveTo(Vector position)
        {
            Position = position;
            Moved?.Invoke();
        }

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}
