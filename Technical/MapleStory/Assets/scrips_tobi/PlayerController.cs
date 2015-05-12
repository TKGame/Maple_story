using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // van toc di chuyen cua Boss
    public float moveSpeed = 1f;

    private Animator anim;

    private float distanceX;

    public GameObject player;

	public static bool facingRight = false;	
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}   
	
	// Update is called once per frame
	void Update () {   
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,0.0f);
        }
	}

    public void FixedUpdate()
    {
        AutoFindPlayer(player.transform);
    }

    public void AutoFindPlayer(Transform playerTranForm)
    {
        distanceX = transform.position.x - playerTranForm.position.x;
		//Debug.Log(distanceX);
		Attack1 ();
		Flip ();
    }

	void Attack1()
	{
		if (player.transform.position.x < transform.position.x) {
			
			if(distanceX < 3)
			{
				anim.SetBool ("isAttack1", true);
			}
			else if(distanceX > 3)
			{
				anim.SetBool ("isMove", true);
				gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,0.0f);
			}
		} else {
			if(distanceX > -3)
			{
				anim.SetBool ("isAttack1", true);
			}
			else if(distanceX < -3)
			{
				anim.SetBool ("isMove", true);
				gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,0.0f);
			}
		}
	}

	void Flip ()
	{
		if (facingRight) {
			// Switch the way the player is labelled as facing.
			facingRight = !facingRight;
			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
	
    public void StandBoss()
    {
		anim.SetBool ("isAttack1", false);
    }

    // xét va chạm của các Colliser2D khi boss tấn công
    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trừ máu Player");
        }
    }


}
