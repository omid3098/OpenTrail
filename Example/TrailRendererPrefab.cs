public class TrailRendererPrefab : TrailPrefab
{
    public override void DisableTrail()
    {
        gameObject.SetActive(false);
    }

    public override void EnableTrail()
    {
        gameObject.SetActive(true);
    }
}
