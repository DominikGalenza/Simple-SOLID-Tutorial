using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MovementInputVector { get; private set; }
    public event Action OnInteractEvent;

	private void Update()
	{
		GetInteractInput();
		GetMovementInput();
	}

	private void GetInteractInput()
	{
		if (Input.GetAxisRaw("Fire1") > 0)
		{
			OnInteractEvent?.Invoke();
		}
	}

	private void GetMovementInput()
	{
		MovementInputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		MovementInputVector.Normalize();
	}
}
