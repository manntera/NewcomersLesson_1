using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlock : BlockBase
{
	[SerializeField]
	private int dealDamage;

	protected override void PlayerBehaviourOnEnter(Player player)
	{
		player.DealDamage(dealDamage);
	}
}