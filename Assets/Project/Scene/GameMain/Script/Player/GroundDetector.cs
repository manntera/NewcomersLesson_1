using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
	[SerializeField]
	private bool isOnGround;

	private Rigidbody2D playerRigidbody;
	private Player player;
	public bool IsOnGround
	{
		private set
		{
			isOnGround = value;
		}
		get
		{
			return isOnGround;
		}
	}
	private void Awake()
	{
		IsOnGround = false;
	}

	private void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			IsOnGround = true;
		}
	}
	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			IsOnGround = false;
		}
	}
}