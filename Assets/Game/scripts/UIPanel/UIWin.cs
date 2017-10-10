using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class UIWin : UIBase
{

	public override void DoOnEntering()
	{
		GetComponent<Canvas>().worldCamera = Camera.main;

		transform.GetChild(0).DOLocalMoveY(0, 1f);
		CanvasGroup.alpha = 1f;
		CanvasGroup.interactable = true;
	}

	public override void DoOnPausing()
	{
		UIManager.Instance.PopUIPanel();
	}

	public override void DoOnResuming()
	{
		CanvasGroup.alpha = 1f;
		transform.GetChild(0).DOLocalMoveY(0, 1f);
		CanvasGroup.interactable = true;
	}

	public override void DoOnExiting()
	{
		CanvasGroup.interactable = false;
		CanvasGroup.alpha = 0f;
		transform.GetChild(0).DOLocalMoveY(700f, 1f);
	}

	public void OnRePlayClick()
	{
		UIManager.Instance.PopUIPanel();
	}
}
