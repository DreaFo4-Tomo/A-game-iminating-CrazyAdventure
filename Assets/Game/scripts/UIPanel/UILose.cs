using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class UILose : UIBase
{
	public Text txt_IQ;

	public override void DoOnEntering()
	{
		GetComponent<Canvas>().worldCamera = Camera.main;

		transform.GetChild(0).DOLocalMoveY(0, 1f);
		int IQ = Random.Range(-800, 20);
		txt_IQ.text = IQ.ToString();
		CanvasGroup.alpha = 1f;
		CanvasGroup.interactable = true;
	}

	public override void DoOnPausing()
	{
		UIManager.Instance.PopUIPanel();
	}

	public override void DoOnResuming()
	{
		int IQ = Random.Range(-800, 20);
		txt_IQ.text = IQ.ToString();
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
