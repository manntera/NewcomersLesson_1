﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBlock : BlockBase
{
	protected override void PlayerBehaviourOnEnter(Player player)
	{
		GameMainManager.Instance.IsStageCleared = true;
	}
}