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
    public PlayerInput playerInput;
    public PlayerAnimations playerAnimations;
    public UIController uiController;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
		playerRenderer = GetComponent<PlayerRenderer>();
		playerAIInteractions = GetComponent<PlayerAIInteractions>();
		playerInput = GetComponent<PlayerInput>();
        playerInput.OnInteractEvent += () => playerAIInteractions.Interact(playerRenderer.IsSpriteFlipped);
        playerAnimations = GetComponent<PlayerAnimations>();
	}

    private void FixedUpdate()
    {
        playerMovement.MovePlayer(playerInput.MovementInputVector);
        playerRenderer.RenderPlayer(playerInput.MovementInputVector);
        playerAnimations.SetupAnimations(playerInput.MovementInputVector);
        if (playerInput.MovementInputVector.magnitude > 0)
        {
            uiController.ToggleUI(false);
		}
    }

    public void ReceiveDamaged()
    {
        playerRenderer.FlashRed();
    }
}
