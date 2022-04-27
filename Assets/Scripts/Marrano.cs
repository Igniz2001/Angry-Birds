using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marrano : MonoBehaviour
{
	public float resistance;
	public GameObject explosionPrefab;
	Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D col)
	{
		if (col.relativeVelocity.magnitude > resistance)
		{

			if (explosionPrefab != null)
			{
				var go = Instantiate(explosionPrefab,
					transform.position,
					Quaternion.identity);


				Destroy(go, 3);
			}

			Destroy(gameObject, 0.1f);

		}
		else
		{
			resistance -= col.relativeVelocity.magnitude;
			if (resistance <= 10)
            {
				animator.SetBool("Aporriado", true);
            }

		}

	}
}
