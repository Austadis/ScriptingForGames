using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        //Cache the Animator component attached to CharacterArt
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        //Handle running and idling
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        
        // Handle Double Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("DoubleJumpTrigger");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        
        // Handle Hit
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("HitTrigger");
        }
        
        // Handle Fall
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("FallTrigger");
        }
    }
}
