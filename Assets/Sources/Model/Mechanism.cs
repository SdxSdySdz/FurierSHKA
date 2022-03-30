using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sources.Model
{
    public class Mechanism : Transformable, IUpdatable
    {
        private List<Circle> _circles;
        private bool _isWorking;
        private double _time;

        public Mechanism()
        {
            _circles = new List<Circle>();
            Speed = 1;
        }

        private Circle LastCirce => _circles[_circles.Count - 1];

        public Vector TipPosition
        {
            get
            {
                if (_circles.Count == 0)
                    return Position;
                else
                    return LastCirce.Position + LastCirce.RadiusVector;
            }
        }

        public List<Circle> Circles => new List<Circle>(_circles);
        public double Speed { get; set; }

        public void Restart()
        {
            _time = 0;
            Start();
        }

        public void Start() => _isWorking = true;

        public void Stop() => _isWorking = false;

        public void Update(float deltaTime)
        {
            if (_isWorking == false)
                return;

            SetState(_time);
            _time += deltaTime * Speed;
        }
        
        public void SetState(double time)
        {
            if (_circles.Count == 0)
                return;

            Circle circle;
            for (int i = 0; i < _circles.Count - 1; i++)
            {
                circle = _circles[i];
                circle.SetState(time);

                _circles[i + 1].MoveTo(circle.Position + circle.RadiusVector);
            }

            circle = _circles[_circles.Count - 1];
            circle.SetState(time);
        }

        public void Add(Circle circle)
        {
            circle.MoveTo(TipPosition);

            _circles.Add(circle);
        }

        public void Sort()
        {
            var sortedCircles = _circles.OrderByDescending(circle => circle.RadiusVector.Magnitude);
            _circles = new List<Circle>();
            foreach (var circle in sortedCircles)
            {
                Add(circle);
            }
        }
    }
}
