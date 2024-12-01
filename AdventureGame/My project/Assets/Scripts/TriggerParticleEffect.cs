using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))] 
[RequireComponent(typeof(Collider))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem myParticleSystem;
    public int firstEmissionAmount = 10;
    public int secondEmissionAmount = 20;
    public int thirdEmissionAmount = 30;
    public float delayBetweenEmissions = 0.5f;

    private void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EmitParticlesCoroutine());
        }
    }

    private IEnumerator EmitParticlesCoroutine()
    {
        myParticleSystem.Emit(firstEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);
        
        myParticleSystem.Emit(secondEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);
        
        myParticleSystem.Emit(thirdEmissionAmount);
    }
}
