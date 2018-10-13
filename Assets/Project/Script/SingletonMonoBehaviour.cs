//-----------------------------------
// このクラスは https://qiita.com/Teach/items/c146c7939db7acbd7eee から持ってきた物です。
// シングルトンと言う方法を使って作成したクラスです。
// 詳しい説明は、上記のURLを見て下さい。
//-----------------------------------

using UnityEngine;
using System;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				Type t = typeof(T);

				instance = (T)FindObjectOfType(t);
				if (instance == null)
				{
					Debug.LogError(t + " をアタッチしているGameObjectはありません");
				}
			}
			return instance;
		}
	}

	virtual protected void Awake()
	{
		CheckInstance();
	}

	protected bool CheckInstance()
	{
		if (instance == null)
		{
			instance = this as T;
			return true;
		}
		else if (Instance == this)
		{
			return true;
		}
		Debug.LogError(typeof(T) + "をアタッチしているGameObjectoが既に存在します");
		Destroy(this);
		return false;
	}
}