using Assets.Sources.Model;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MechanismPresenter _mechanismPresenter;
    [SerializeField] private int _clockwiseCirclesCount;
    [SerializeField] private int _integrationPointsCount;

    private ICurve _curve;
    private MechanismSolver _mechanismSolver;
    private Mechanism _mechanism;

    private void Awake()
    {
        _curve = new ClosedPolyline(new[]
        {
            new Vector(0, 0),
            new Vector(1, 1),
            new Vector(2, 0),
        });

        _mechanismSolver = new MechanismSolver(_curve);
        Debug.LogError("Start solving");
        _mechanism = _mechanismSolver.Solve(_clockwiseCirclesCount, _integrationPointsCount);
        Debug.LogError("End solving");
        _mechanism.Sort();


        _mechanismPresenter.Init(_mechanism, _camera);

        _mechanism.Start();
    }
}
