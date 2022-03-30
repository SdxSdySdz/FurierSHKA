using Assets.Sources.Model;
using UnityEngine;

public class CirclePresenter : Presenter
{
    public new Circle Model => base.Model as Circle;

    protected override void OnInit()
    {
        float diameter = (float)(2 * Model.RadiusVector.Magnitude);
        transform.localScale = new Vector3(diameter, diameter, 1);
    }
}
