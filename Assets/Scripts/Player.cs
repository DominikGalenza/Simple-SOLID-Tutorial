using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerRenderer playerRenderer;
    public PlayerAIInteractions playerAIInteractions;
    public IMovementInput movementInput;
    public PlayerAnimations playerAnimations;
    public UIController uiController;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
		playerRenderer = GetComponent<PlayerRenderer>();
		playerAIInteractions = GetComponent<PlayerAIInteractions>();
		movementInput = GetComponent<PlayerInput>();
        movementInput.OnInteractEvent += () => playerAIInteractions.Interact(playerRenderer.IsSpriteFlipped);
        playerAnimations = GetComponent<PlayerAnimations>();
	}

    private void FixedUpdate()
    {
        playerMovement.MovePlayer(movementInput.MovementInputVector);
        playerRenderer.RenderPlayer(movementInput.MovementInputVector);
        playerAnimations.SetupAnimations(movementInput.MovementInputVector);
        if (movementInput.MovementInputVector.magnitude > 0)
        {
            uiController.ToggleUI(false);
		}
    }

    public void ReceiveDamaged()
    {
        playerRenderer.FlashRed();
    }
}
