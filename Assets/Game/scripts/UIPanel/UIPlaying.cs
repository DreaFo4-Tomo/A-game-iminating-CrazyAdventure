using UnityEngine;
using System.Collections;

public class UIPlaying : UIBase
{
	public override void DoOnEntering()
	{
		gameObject.SetActive(true);
		SoundManager.Instance.PlayBGM("Audio_bgm_startup_cg");
		Camera.main.GetComponent<FollowPlayer>().enabled = true;
	}

	public override void DoOnPausing()
	{
		SoundManager.Instance.StopBGM();
	}

	public override void DoOnResuming()
	{
		HeroController.Instance.ResetPlayer();
		SoundManager.Instance.PlayBGM("Audio_bgm_startup_cg");
		ResetObject[] ros = GameObject.FindObjectsOfType<ResetObject>();
		for (int i = 0; i < ros.Length; i++) {
			ros [i].Reset ();
		}
	}

	public override void DoOnExiting()
	{
		SoundManager.Instance.StopBGM();
	}

}
