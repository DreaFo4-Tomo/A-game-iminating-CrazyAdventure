using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CollisionCondition : MonoBehaviour
{
	public bool NeedDie = false;
	public bool NeedWin = false;
	//需要保存进度
	public bool NeedSave = false;

	public UnityEvent OnCollisionHandler;

	void OnCollisionEnter2D(Collision2D collision)
	{
		OnCollisionHandler.Invoke();

		if (NeedDie)
		{
			HeroController.Instance.IsDead = true;
		}
		else if (NeedWin)
		{
			HeroController.Instance.IsWin = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (NeedSave)
		{
			HeroController.Instance.DefaultPosition = transform.position;
			SoundManager.Instance.PlayAudio ("Audio_award");
		}

		OnCollisionHandler.Invoke();

		if (NeedDie)
		{
			HeroController.Instance.IsDead = true;
		}
		else if (NeedWin)
		{
			HeroController.Instance.IsWin = true;
		}
	}
}
