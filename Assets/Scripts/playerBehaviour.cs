using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour {
    private Animator anim;
    private SpriteRenderer srPlayer;
    private Rigidbody2D rbPlayer;

    private float horizontal;
    private float vertical;
    private bool jump = false;
    private bool jumping = false;
    
    public float speed = 1f;
    public GameObject mainCamera;

    private void Awake() {
        anim =     GetComponent<Animator>();
        srPlayer = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetKeyDown (KeyCode.UpArrow);
        onMovePlayer();
        onAnimPlayer();
        mainCamera.transform.position = 
            new Vector3(transform.position.x, 
                        mainCamera.transform.position.y, 
                        mainCamera.transform.position.z);
    }

    private void onAnimPlayer() { 
        anim.SetBool("walk", horizontal != 0);
        if (horizontal < 0)
            srPlayer.flipX = false;
        if (horizontal > 0)
            srPlayer.flipX = true;
        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("attack");
        }
        if (jump) {
            jumping = true;
            anim.SetBool("jump", true);
        }
    }

    private void onMovePlayer() {
        transform.position = transform.position + 
            new Vector3((horizontal*-1) * speed * Time.deltaTime, 0, 0);
        if (jump && !jumping)
            rbPlayer.AddForce(new Vector2(0, 300));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ground") {
            anim.SetBool("jump", false);
            jumping = false;
        }
    }
}