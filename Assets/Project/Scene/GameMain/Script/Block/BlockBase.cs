using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockBase : MonoBehaviour {
	protected abstract void PlayerBehaviourOnEnter(Player player);

	private void OnTriggerEnter2D(Collider2D col)
	{
		var go = col.gameObject;
		if (go.tag == "Player")
		{
			PlayerBehaviourOnEnter(go.GetComponent<Player>());
		}
	}
}
