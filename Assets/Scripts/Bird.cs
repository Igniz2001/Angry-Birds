using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
	public Transform pivot;
	public float springRange;
	public float maxVel;
	Animator animator;

	Rigidbody2D rb;
	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		rb.bodyType = RigidbodyType2D.Kinematic;
	}

	bool canDrag = true;
	Vector3 dis;
	void OnMouseDrag()
	{
		if (!canDrag)
			return;

		var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		dis = pos - pivot.position;
		dis.z = 0;
		if (dis.magnitude > springRange)
		{
			dis = dis.normalized * springRange;
		}
		transform.position = dis + pivot.position;
	}

	void OnMouseUp()
	{
		if (!canDrag)
			return;
		canDrag = false;

		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.velocity = -dis.normalized * maxVel * dis.magnitude / springRange;
	}

    private void OnCollisionEnter2D(Collision2D other)
	{
        if(other.gameObject.tag == "Madera")
        {
			animator.SetBool("Damage",true);
        }
    }
}
