using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIStartup : UIBase 
{
	public override void DoOnEntering()
	{
		GetComponent<Canvas> ().worldCamera = Camera.main;
		gameObject.SetActive (true);
		SoundManager.Instance.PlayBGM("Audio_yyqx");
		CanvasGroup.interactable = true;
		CanvasGroup.alpha = 1f;
	}

	public override void DoOnPausing()
	{
		CanvasGroup.interactable = false;
		CanvasGroup.DOFade(0f, .4f);
		gameObject.SetActive (false);
		//SoundManager.Instance.StopBGM();
	}

	public override void DoOnResuming()
	{
		CanvasGroup.interactable = true;
		CanvasGroup.DOFade(1f, .4f);
		gameObject.SetActive (true);
		//SoundManager.Instance.PlayBGM("Audio_yyqx");
	}

	public override void DoOnExiting ()
	{
		CanvasGroup.DOFade(0f, .4f);
		CanvasGroup.interactable = false;
		gameObject.SetActive (false);
		SoundManager.Instance.StopBGM();
	}

	public void GoToSetting()
	{
		UIManager.Instance.PushUIPanel("UISetting");
	}

	public void GoToPlay()
	{
		UIManager.Instance.PushUIPanel("UIPlaying");
	}
}
