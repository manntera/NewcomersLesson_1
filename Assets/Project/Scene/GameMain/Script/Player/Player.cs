using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private float jumpPower;
	[SerializeField]
	private int lifePoint;
	[SerializeField]
	private GroundDetector groundDetector;

	private Rigidbody2D rigidbody2d;
	private Vector2 velocity;
	private bool isJumped;

	public Vector2 Velocity
	{
		set { velocity = value; }
	}

	public float JumpPower
	{
		get { return jumpPower; }
	}
	public int LifePoint
	{
		get { return lifePoint; }
	}

	private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		if (lifePoint <= 0)
		{
			GameMainManager.Instance.IsStageFailed = true;
		}
		if (GameMainManager.Instance.IsGameOver == false)
		{
			velocity = rigidbody2d.velocity;
			velocity.x = 0;
			Vector3 scale = transform.localScale;
			if (Input.GetKey(KeyCode.A))
			{
				velocity.x = -speed;
				scale.x = -1;
			}
			if (Input.GetKey(KeyCode.D))
			{
				velocity.x = speed;
				scale.x = 1;
			}
			if (isJumped == true && groundDetector.IsOnGround == false)
			{
				isJumped = false;
			}
			if (Input.GetKeyDown(KeyCode.Space) && groundDetector.IsOnGround == true && isJumped == false)
			{
				isJumped = true;
				Debug.Log("Jump");
				velocity.y = 0;
				rigidbody2d.AddForce(Vector2.up * JumpPower);
			}
			transform.localScale = scale;
			rigidbody2d.velocity = velocity;
		}
		else
		{
			rigidbody2d.Sleep();
		}
	}
	public void DealDamage(int damage)
	{
		lifePoint -= damage;
		lifePoint = Mathf.Max(lifePoint, 0);
	}
}