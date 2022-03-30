using Assets.Sources.Model;
using System.Linq;
using UnityEngine;

public class MechanismPresenter : Presenter
{
    [SerializeField] private double _speed = 1;
    [SerializeField] private PresentersFactory _presentersFactory;

    public new Mechanism Model => base.Model as Mechanism;

    private void OnValidate()
    {
        Model.Speed = _speed;
    }

    protected override void OnInit()
    {
        SpawnCircles();
    }

    private void SpawnCircles()
    {
        
        foreach (Circle circle in (Model as Mechanism).Circles)
        {
            _presentersFactory.CreateCircle(circle);
        }
    }
}
