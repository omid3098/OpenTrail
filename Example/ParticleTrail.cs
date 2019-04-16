using UnityEngine;
public class ParticleTrail : TrailPrefab
{
    [SerializeField] ParticleSystem particle;
    public override void DisableTrail()
    {
        particle.Stop();
    }

    public override void EnableTrail()
    {
        particle.Play();
    }
}