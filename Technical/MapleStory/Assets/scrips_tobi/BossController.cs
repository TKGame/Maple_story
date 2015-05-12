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

	public GameObject frontCheck;

	public static bool isAttack2 = false;

	public GameObject hitAttack2;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}   
	
	public void FixedUpdate()
	{
		Flip ();
		distanceX = Mathf.Abs( transform.position.x - player.transform.position.x);

		if (distanceX <11.0f && distanceX > 10.0f) {
			Attack2 ();
		} else {
			AutoFindPlayer (distanceX);
		}
	}

	void Attack2()
	{
		anim.SetBool ("isAttack2", true);
	}

	public void CreateHitAttack2()
	{
		Instantiate (hitAttack2, new Vector3(transform.position.x-1,transform.position.y -1 , transform.position.z),transform.rotation);
	}

	public void UnSetAttiveAttack2()
	{
		//frontCheck.SetActive (false);
		isAttack2 = false;
		anim.SetBool ("isAttack2", isAttack2);
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
			int num = Random.Range(0,3);
			{
				if(num == 0)
				{
					Attack1();
				}
				else if(num ==1)
				{
					Attack4();
				}
				else 
				{
					Attack3();
				}
			}
			startTime = Time.time;
		}
	}

	// di chuyen
	public void AutoMove(float distance)
	{
		anim.SetBool ("isMove", true);
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,0.0f);
	}

	// xoay
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

	void Attack3()
	{
		anim.SetBool ("isAttack3", true);
		anim.SetBool ("isMove", false);
	}

	//void Attack2()
	//{
	//	anim.SetBool ("isAttack2", true);
	//	anim.SetBool ("isMove", false);
	//}

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
		anim.SetBool ("isAttack3", false);
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
