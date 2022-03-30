using Assets.Sources.Model;
using UnityEngine;

public abstract class Presenter : MonoBehaviour
{
    private Camera _camera;
    private Transformable _model;

    private IUpdatable _updatable = null;

    public Transformable Model => _model;

    public void Init(Transformable model, Camera camera)
    {
        _camera = camera;
        _model = model;

        if (_model is IUpdatable)
            _updatable = (IUpdatable)_model;

        enabled = true;

        OnMoved();
        OnInit();
    }

    private void OnEnable()
    {
        _model.Moved += OnMoved;
        _model.Destroying += OnDestroying;
    }

    private void OnDisable()
    {
        _model.Moved -= OnMoved;
        _model.Destroying -= OnDestroying;
    }

    private void Update() => _updatable?.Update(Time.deltaTime);

    protected virtual void OnInit() { }

    protected void DestroyCompose()
    {
        _model.Destroy();
    }

    private Vector3 GetViewportPosition(Transformable transformable)
    {
        return new Vector3((float)transformable.Position.X, (float)transformable.Position.Y, 1);
    }

    private void OnMoved()
    {
        // transform.position = _camera.ViewportToWorldPoint(GetViewportPosition(_model));
        transform.position = new Vector3((float)_model.Position.X, (float)_model.Position.Y, 0);
    }

    private void OnDestroying()
    {
        Destroy(gameObject);
    }
}
