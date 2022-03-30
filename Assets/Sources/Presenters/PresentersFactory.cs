using Assets.Sources.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CirclePresenter _circlePrefab;

    public void CreateCircle(Circle circle)
    {
        CreatePresenter(_circlePrefab, circle);
    }

    private Presenter CreatePresenter(Presenter template, Transformable model)
    {
        Presenter presenter = Instantiate(template);
        presenter.Init(model, _camera);

        return presenter;
    }
}
