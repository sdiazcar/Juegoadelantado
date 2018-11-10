using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour {

    public Animator animatorCharacter;
    bool isRunning = false;
	// Use this for initialization
	void Start () {
        animatorCharacter = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        isRunning = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * 0.3f);
            isRunning = true;
            this.GetComponent<SpriteRenderer>().flipX = false;


        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * 0.3f);
            isRunning = true;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        animatorCharacter.SetBool("RunningPersonajePrincipal", isRunning);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.0f, ForceMode2D.Impulse);
            animatorCharacter.SetBool("FloorPersonajePrincipal", false);
        }

    }
    void OnCollisionEnter2D(Collision2D col){
        animatorCharacter.SetBool("FloorPersonajePrincipal", true);
    }
}
