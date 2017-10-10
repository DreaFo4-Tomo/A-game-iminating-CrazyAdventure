using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
	private Transform player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{

		float x = Mathf.Lerp(transform.position.x, player.position.x, Time.deltaTime * 4f);

		x = Mathf.Clamp (x, 4.7f, 15.4f);

		transform.position = new Vector3(x, transform.position.y, -9.3f);


	}
}
