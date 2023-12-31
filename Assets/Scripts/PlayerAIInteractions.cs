using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAIInteractions : MonoBehaviour
{
	public Transform raycastPoint;

	public void Interact(bool isSprteFlipped)
	{
		Debug.DrawRay(raycastPoint.position, isSprteFlipped ? Vector3.left : Vector3.right, Color.red);
		RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, isSprteFlipped ? Vector3.left : Vector3.right, 1);
		if (hit.collider != null)
		{
			if (hit.collider.GetComponent<NPC>())
			{
				hit.collider.GetComponent<NPC>().Interact();
			}

			IHittable hittable = hit.collider.GetComponent<IHittable>();
			hittable?.GetHit();
		}
	}
}
