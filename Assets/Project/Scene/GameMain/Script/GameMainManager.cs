using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : SingletonMonoBehaviour<GameMainManager>
{
	[SerializeField]
	private bool isStageCleared;
	[SerializeField]
	private bool isStageFailed;

	public bool IsStageCleared
	{
		get
		{
			return isStageCleared;
		}
		set
		{
			if (value == true)
			{
				isStageFailed = false;
			}
			isStageCleared = value;
		}
	}
	public bool IsStageFailed
	{
		get
		{
			return isStageFailed;
		}
		set
		{
			if (value == true)
			{
				isStageCleared = false;
			}
			isStageFailed = value;
		}
	}
	public bool IsGameOver
	{
		get { return isStageCleared || isStageFailed; }
	}
}