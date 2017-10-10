using UnityEngine;
using System.Collections;


public class HeroController : MonoBehaviour
{
	public static HeroController Instance;

	public float MoveSpeed = 2f;

	public float JumpPower = 300f;

	public Vector3 DefaultPosition;

	public bool isDead = false;
	public bool isWin = false;

	public bool IsDead
	{
		get { return isDead; }
		set
		{
			if (isDead != value)
			{
				isDead = value;
				if (value)
				{
					SoundManager.Instance.PlayAudio("Audio_ao");
					UIManager.Instance.PushUIPanel("UILose");
				}
			}
		}
	}

	public bool IsWin
	{
		get { return isWin; }
		set
		{
			if (isWin != value)
			{
				isWin = value;
				if (value)
				{
					SoundManager.Instance.PlayAudio("Audio_congratulations");
					UIManager.Instance.PushUIPanel("UIWin");
				}
			}
		}
	}


	private Rigidbody2D Rigidbody2D;
	private HeroAnim HeroAnim;

	void Awake() { Instance = this; }

	void Start()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();
		HeroAnim = GetComponent<HeroAnim>();

		DefaultPosition = transform.position;
	}

	void Update()
	{
		if (isDead)
		{
			HeroAnim.DieState();
			Rigidbody2D.velocity = new Vector2(0f, Rigidbody2D.velocity.y);

			return;
		}

		if (transform.localPosition.y < -500)
		{
			IsDead = true;
		}
	}

	void FixedUpdate()
	{
		if (isDead) 
		{
			HeroAnim.DieState ();
			return;
		}

		float h = Input.GetAxis("Horizontal");

		if (Mathf.Abs(h - 0) > 0.01f)
		{
			Rigidbody2D.velocity = new Vector2(h * MoveSpeed, Rigidbody2D.velocity.y);

			HeroAnim.WalkState(h < 0);
		}
		else
		{
			HeroAnim.IdleState();
			Rigidbody2D.velocity = new Vector2(0f, Rigidbody2D.velocity.y);
		}

		//detecting the jumping
		if (Rigidbody2D.velocity.y == 0)//If the hero is not at the ground,he can't jump.
		{
			if (Input.GetKeyDown(KeyCode.Space))//The space button is pressed.
			{
				Rigidbody2D.AddForce(Vector2.up * JumpPower);
				HeroAnim.JumpState(true);
			}
			else
				HeroAnim.JumpState(false);
		}

	}


	public void ResetPlayer()
	{
		transform.position = DefaultPosition;
		IsDead = false;
		HeroAnim.IdleState();
	}
}
