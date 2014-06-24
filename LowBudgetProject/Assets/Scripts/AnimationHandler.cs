using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour {
	public CharacterMovement characterMovement;
	
	void Awake () {
		characterMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FinishAttack(){
		characterMovement.FinishAttack ();
	}
}
