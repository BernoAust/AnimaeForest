using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    public Camera cam;

    public Rigidbody2D rb;

    public int Hp = 10;

    public float Damage;

    public Vector2 Velocity;

    public string Name = "Player";

    public float Speed = 10f;

    public float JumpHeight = 5f;

    public float TimeToJumpApex = 0.5f;

    public float Gravity;

    public float JumpVelocity;

    public bool OnGround;

    public float Horizontal;

    public Animator animator;

    public GameManager GM;

    public CameraController CamCtrl;

    public EnemyAI EnemyScript;

    public HealthBar HealthBar;

    private void Awake()
     {
        rb = GetComponent<Rigidbody2D>();
        Velocity = new Vector2();
     }

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        transform.position = GM.LastCheckpointPos;
        CamCtrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        HealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        HealthBar.SetMaxHealth(Hp);
    }

    void Update()
    {

     PlayerMovement();

     HealthManager();

     CalculateJump();

     PlayerJump();

     //PlayerMovement();

     PlayerRotation();

     WalkAnimation();

     CheckPlayerDeath();

     HealthBar.SetHealth(Hp);

     }

    void PlayerMovement() //movimento do player.
    {
        Horizontal = Input.GetAxis("Horizontal");
        Velocity.y = rb.velocity.y;
        Velocity.x = Horizontal * Speed;
    }

    void HealthManager() // causa dano e evita dano continuo.
    {
        Hp += Mathf.RoundToInt(Damage);

        if (Damage < -0.5f)
        {
            Damage = 0.0f;
        }
    }

    void CalculateJump() // calcula pulo.
    {
        Gravity = -(2 * JumpHeight) / Mathf.Pow(TimeToJumpApex, 2);
        Physics2D.gravity = new Vector2(0, Gravity);
        JumpVelocity = Mathf.Abs(Gravity) * TimeToJumpApex;
    }

    void PlayerJump() //executa pulo se jogador estiver no chão.
    {
        if (Input.GetKeyDown(KeyCode.W) && OnGround)
        {
            Velocity.y += JumpVelocity;
            OnGround = false;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            Velocity.y += JumpVelocity;
            OnGround = false;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround)
        {
            Velocity.y += JumpVelocity;
            OnGround = false;
        }

        rb.velocity = Velocity;
    }

    private void OnTriggerStay2D(Collider2D other) //checa se o jogador está no chão para pular.
    {
        if (other.gameObject.tag == "Ground")
        {
            OnGround = true;
        }
    }

    void PlayerRotation()
    {

        if (Velocity.x > 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Velocity.x < 0)
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);

        }

    }

    void WalkAnimation()
    {

        animator.SetFloat("HorizontalVelocity", Mathf.Abs(Velocity.x));

    }

    void CheckPlayerDeath()
    {
        if(Hp <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
        GM.Respawn();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
