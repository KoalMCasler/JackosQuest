using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRB;
    private Vector3 moveInput;
    public int moveSpeed = 5;
    public int speedMultiplier = 2;
    public GameManager gameManager;
    public UIManager uIManager;
    [SerializeField]
    private Animator playerAnim;
    public bool IsSprinting;

    void Awake()
    {
        IsSprinting = false;
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        if(Input.GetButton("Sprint"))
        {
            IsSprinting = true;
        }
        else
        {
            IsSprinting = false;
        }
    }
    void FixedUpdate()
    {
        Move();
        PauseGame();
    }
    void Move()
    {
        if(moveInput.x == 0 && moveInput.y == 0)
        {
            playerAnim.SetBool("IsIdle", true);
        }
        else
        {
            if(IsSprinting)
            {
                playerAnim.speed = speedMultiplier;
                playerAnim.SetBool("IsIdle", false);
                playerRB.MovePosition(transform.position + moveInput.normalized * moveSpeed * speedMultiplier * Time.fixedDeltaTime);
                playerAnim.SetFloat("InputX", moveInput.x);
                playerAnim.SetFloat("InputY", moveInput.y);

                CheckDirection();
            }
            else
            {
                playerAnim.speed = 1; //Defult playback speed
                playerAnim.SetBool("IsIdle", false);
                playerRB.MovePosition(transform.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
                playerAnim.SetFloat("InputX", moveInput.x);
                playerAnim.SetFloat("InputY", moveInput.y);
                CheckDirection();
            }
        }
    }
    void CheckDirection()
    {
        if(moveInput.x > 0)
        {
            playerAnim.SetBool("IsFacingRight", true);
            playerAnim.SetBool("IsFacingUp", false);
            playerAnim.SetBool("IsFacingLeft", false);
            playerAnim.SetBool("IsFacingDown", false);

        }
        if(moveInput.y > 0)
        {
            playerAnim.SetBool("IsFacingUp", true);
            playerAnim.SetBool("IsFacingLeft", false);
            playerAnim.SetBool("IsFacingDown", false);
            playerAnim.SetBool("IsFacingRight", false);
        }
        if(moveInput.x < 0)
        {
            playerAnim.SetBool("IsFacingLeft", true);
            playerAnim.SetBool("IsFacingDown", false);
            playerAnim.SetBool("IsFacingRight", false);
            playerAnim.SetBool("IsFacingUp", false);
        }
        if(moveInput.y < 0)
        {
            playerAnim.SetBool("IsFacingDown", true);
            playerAnim.SetBool("IsFacingUp", false);
            playerAnim.SetBool("IsFacingLeft", false);
            playerAnim.SetBool("IsFacingRight", false);
        }
    }
    void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && uIManager.GameIsPause == false)
        {
            gameManager.gameState = GameManager.GameState.Paused;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && uIManager.GameIsPause == true)
        {
            gameManager.gameState = GameManager.GameState.Gameplay;
        }
    }


}
