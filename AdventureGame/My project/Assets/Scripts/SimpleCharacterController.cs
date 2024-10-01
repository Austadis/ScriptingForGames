using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController _controller;
    private Transform _thisTransform;
    private Vector3 _movementVector = Vector3.zero;

    private void Start()
    {
        // Cache references to components
        _controller = GetComponent<CharacterController>();
        _thisTransform = transform;
    }

    private void Update()
    {
        MoveCharacter();
        KeepCharacterOnXAxis();
    }

    private void MoveCharacter()
    {
        _movementVector.x = Input.GetAxis("Horizontal");
        _movementVector *= (moveSpeed * Time.deltaTime);
        _controller.Move(_movementVector);
    }

    private void KeepCharacterOnXAxis()
    {
        // Use cached transform reference and optimize vector creation
        var currentPosition = _thisTransform.position;
        currentPosition.z = 0f;
        _thisTransform.position = currentPosition;
    }
}

