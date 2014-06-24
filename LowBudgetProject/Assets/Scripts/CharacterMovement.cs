using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour{
	public float moveDirection;
	public float maxSpeed = 4.0f;
	public bool facingRight = true;
	public float jumpSpeed = 250.0f;
	public bool grounded = false;
	public Animator animator;
	public bool attackRight = false;
	//public AudioSource audioSource;

	void Awake(){
		//audioSource = GetComponent<AudioSource> ();
		animator = GetComponentInChildren<Animator> ();
	}

	void Start(){
		//audioSource.Play ();
	}

	void FixedUpdate () {
		rigidbody.velocity = new Vector2 (moveDirection * maxSpeed,rigidbody.velocity.y);

		if (moveDirection > 0.0f && !facingRight) {
			Flip();		
		}
		if (moveDirection < 0.0f && facingRight) {
			Flip();		
		}
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump")) {
			if(grounded == true){
				rigidbody.AddForce(new Vector2(0,jumpSpeed));	
				grounded = false;
			}
		}

		if (Input.GetButtonDown ("Fire1")) {
			if(!attackRight){
				attackRight = true;
				animator.SetBool("Attack_R",true);
			}else{
				attackRight = false;
				animator.SetBool("Attack_L",true);
			}
		}
	}

	void Flip(){
		facingRight = !facingRight;
		transform.Rotate (Vector3.up,180.0f,Space.World);
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Floor"){
			grounded = true;
		}
	}

	public void FinishAttack(){
		animator.SetBool("Attack_L",false);
		animator.SetBool("Attack_R",false);	
	}
}
