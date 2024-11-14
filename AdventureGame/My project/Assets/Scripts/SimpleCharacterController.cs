using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;

    private CharacterController _controller;
    private Transform _thisTransform;
    private Vector3 velocity;
    
    public SimpleFloatData StaminaDataObj;
    public SimpleImageBehaviour staminaImageBehaviour; 
    private void Start()
    {
        // Cache references to components
        _controller = GetComponent<CharacterController>();
        _thisTransform = transform;
        
        // Debug to check if staminaDataObj is assigned
        if (StaminaDataObj == null)
        {
            Debug.LogError("StaminaData object is not assigned in the Inspector!");
        }
        
        // Check if UI Image reference is properly set
        if (staminaImageBehaviour == null)
        {
            Debug.LogError("Stamina Image Behaviour is not assigned in the Inspector!");
        }
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
        HandleStamina();
        
        // Jumping
        if (Input.GetButtonDown("Jump") && _controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void MoveCharacter()
    {
        // Horizontal Movement
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime);
        _controller.Move(move);
    }
    
    private void ApplyGravity()
    {
        // Apply gravity when not grounded
        if (!_controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
        }
        
        // Apply the velocity to the controller
        _controller.Move(velocity * Time.deltaTime);
    }
    
    private void KeepCharacterOnXAxis()
    {
        // Use cached transform reference and optimize vector creation
        var currentPosition = _thisTransform.position;
        currentPosition.z = 0f;
        _thisTransform.position = currentPosition;
    }

    private void HandleStamina()
    {
        if (StaminaDataObj == null)
        {
            Debug.LogError("StaminaData reference is null! Cannot handle stamina.");
            return;
        }
        
        // Check if the player is running (horizontal movement > 0.1f)
        float horizontalMovement = Mathf.Abs(Input.GetAxis("Horizontal"));
        if (horizontalMovement > 0.1f) // Player is running
        {
            StaminaDataObj.UpdateValue(-0.1f * Time.deltaTime); // Decrease Stamina
        }
        else // Player is idle
        {
            StaminaDataObj.UpdateValue(0.15f * Time.deltaTime); // Slowly replenish stamina
        }
        
        // Clamp the Stamina value between 0 and 1
        StaminaDataObj.value = Mathf.Clamp(StaminaDataObj.value, 0f, 1f);
        
        //Update the Stamina UI Image after handling stamina
        if (staminaImageBehaviour != null)
        {
            staminaImageBehaviour.UpdateWithFloatData(false);
        }
    }
}

