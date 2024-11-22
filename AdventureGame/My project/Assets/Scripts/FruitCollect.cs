using System.Collections;
using UnityEngine;

public class FruitCollect : MonoBehaviour
{
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void PlayCollectedAnimation()

        {
            Debug.Log("Fruit collected! Playing animations.");
            animator.SetTrigger("CollectedTrigger");
            StartCoroutine(DisableAfterAnimation());
        }

    private IEnumerator DisableAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }
}
