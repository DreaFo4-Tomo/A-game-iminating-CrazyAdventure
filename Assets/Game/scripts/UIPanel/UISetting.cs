using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UISetting : UIBase 
{
	public override void DoOnEntering()
	{
		GetComponent<Canvas> ().worldCamera = Camera.main;
		CanvasGroup.interactable = true;
		gameObject.SetActive (true);
		CanvasGroup.DOFade(1f, .4f);
	}

	public override void DoOnPausing()
	{
		CanvasGroup.interactable = false;
	}

	public override void DoOnResuming()
	{
		CanvasGroup.interactable = true;
	}

	public override void DoOnExiting ()
	{
		
		CanvasGroup.DOFade(0f, .4f);
		CanvasGroup.interactable = false;
		gameObject.SetActive (false);
	}

	public void GoToStartup()
	{
		UIManager.Instance.PopUIPanel();
	}
		
	public void SetBGMMute(bool mute)
	{
		SoundManager.Instance.Mute = mute;
	}
}
