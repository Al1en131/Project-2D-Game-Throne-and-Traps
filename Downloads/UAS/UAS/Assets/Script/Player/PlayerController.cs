using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    public static PlayerController Instance;

    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    private Knockback knockback;
    private Vector3 respawnPoint;

    private bool facingLeft = false;

    private void Awake() {
        Instance = this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();

        respawnPoint = transform.position; 
    }

        private void Start() {

    }

     private void OnDisable() {
        playerControls.Disable();
    }


    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update() {
        PlayerInput();
    }

    private void FixedUpdate() {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput() {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move() {
        if (knockback.gettingKnockedBack || PlayerHealth.Instance.isDead) { return; }

        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x) {
            mySpriteRender.flipX = true;
            FacingLeft = true;
        } else {
            mySpriteRender.flipX = false;
            FacingLeft = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "NextLevel") {
            SceneManager.LoadScene(1); 
            respawnPoint = transform.position; 
        } else if (collision.tag == "PreviousLevel") {
            SceneManager.LoadScene(0);
            respawnPoint = transform.position; 
        } else if (collision.tag == "NextLevel2") {
            SceneManager.LoadScene(2);
            respawnPoint = transform.position; 
        } else if (collision.tag == "NextLevel3") {
            SceneManager.LoadScene(3);
            respawnPoint = transform.position; 
        } 
    }
}
