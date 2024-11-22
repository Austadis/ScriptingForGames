using System.Collections;
using UnityEngine;

public class EnemyObjectController : MonoBehaviour
{
    private Animator animator;
    public float interval = 3.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        StartCoroutine(SwitchEnemyState());
    }

    private IEnumerator SwitchEnemyState()
    {
        while (true)
        {
            animator.SetTrigger("TurnOnTrigger");
            
            yield return new WaitForSeconds(5.0f);
            
            animator.ResetTrigger("TurnOnTrigger");
            
            yield return new WaitForSeconds(2.0f);
        }
    }
}
