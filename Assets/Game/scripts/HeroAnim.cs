using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroAnim : MonoBehaviour
{
	private Animator Animator;

	void Start()
	{
		Animator = GetComponent<Animator>();
	}


	public void IdleState()
	{
		Animator.SetBool("Die", false);

		Animator.SetFloat("Walk", 1.0f);

		Animator.SetBool("Jump", false);
	}

	public void WalkState(bool isLeft)
	{
		float value = isLeft ? 0 : 2;
		Animator.SetFloat("Walk", value);
	}

	public void JumpState(bool jump)
	{
		if (jump) {
			Animator.SetBool ("Jump", true);
			SoundManager.Instance.PlayAudio ("Audio_jump");
		}
		else
			Animator.SetBool("Jump", false);
	}


	bool isDead = false;

	public void DieState()
	{
		if (!isDead)
		{
			Animator.SetBool("Die", true);
			isDead = false;
		}
	}


}

