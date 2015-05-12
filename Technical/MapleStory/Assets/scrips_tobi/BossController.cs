using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	public float moveSpeed = 1f;
	
	private Animator anim;
	
	private float distanceX;
	
	public GameObject player;

	float subTime = 0.0f;

	float startTime =0.0f;

	public float distanceTime = 0.0f;
	
	public static bool facingRight = false;	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}   



	public void FixedUpdate()
	{
		Flip ();
		distanceX = Mathf.Abs( transform.position.x - player.transform.position.x);

		AutoFindPlayer (distanceX);


	}

	// khi ngoai khoang cach tan cong -> di chuyen theo player
	public void AutoFindPlayer(float dis)
	{
		if (distanceX < 3) {
			Attack();
		} else {
			AutoMove (distanceX);
		}
	}

	// khi trong khoang cach tan cong 
	// 
	public void Attack()
	{
		subTime = Time.time - startTime;
		
		if (subTime > distanceTime) {
			int num = Random.Range(0,2);
			{
				if(num == 0)
				{
					Attack1();
				}
				else
				{
					Attack4();
				}
			}
			startTime = Time.time;
		}
	}
	
	public void AutoMove(float distance)
	{
		anim.SetBool ("isMove", true);
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,0.0f);
	}
	
	void Flip ()
	{
		if (facingRight) {

			moveSpeed = moveSpeed*-1.0f;
			// Switch the way the player is labelled as facing.
			facingRight = !facingRight;
			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	void Attack1()
	{
		anim.SetBool ("isAttack1", true);
		anim.SetBool ("isMove", false);
	}

	void Attack2()
	{
		anim.SetBool ("isAttack2", true);
		anim.SetBool ("isMove", false);
	}

	void Attack4()
	{
		anim.SetBool ("isAttack4", true);
		anim.SetBool ("isMove", false);
	}

	public void StandBoss()
	{
		//anim.SetBool ("isAttack1", false);
		anim.SetTrigger ("stand");
		anim.SetBool ("isAttack4", false);
		anim.SetBool ("isAttack1", false);
	}
	
	// xét va chạm của các Colliser2D khi boss tấn công
	void OnTriggerEnter2D(Collider2D other)
	{   
		if (other.gameObject.tag == "Player")
		{
			//Debug.Log("Trừ máu Player");
		}
	}

}
