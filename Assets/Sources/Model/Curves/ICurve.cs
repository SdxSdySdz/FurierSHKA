namespace Assets.Sources.Model
{
    public interface ICurve
    {
        Vector Interpolate(double time);
    }
}
