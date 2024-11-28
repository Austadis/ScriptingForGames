using UnityEngine;

[RequireComponent(typeof(ParticleSystem))] 
[RequireComponent(typeof(Collider))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem myParticleSystem;
    public int particleAmount = 10;

    private void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myParticleSystem.Play();
        }
    }
}
