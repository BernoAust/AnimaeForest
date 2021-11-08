using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Transform Player;
    public PlayerController PlayerScript;
    public float EnemyViewRange;
    public float EnemySpeed;
    private Rigidbody2D rbEnemy;
    private float EnemyDPS;

    void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        EnemyDPS = 1.5f;
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        
        EnemyViewRange = 20f;
        EnemySpeed = 10f;

    }

    
    void Update()
    {
        // codigo para achar a distancia entre jogador e inimigo.
        float distToPlayer = Vector2.Distance(transform.position, Player.position);

        if (distToPlayer < EnemyViewRange)
        {
            //codigo para inimigo perseguir jogador.
            ChasePlayer();
        }
        else
        {
            //inimigo para de perseguir jogador.
            StopChasingPlayer();
        }


    }

    void ChasePlayer()
    {
        rbEnemy.gravityScale = 0;
        //inimigo flutua.

        if(transform.position.x < Player.position.x)
        {
            //inimigo posicionado a esquerda do jogador. Se move para direita.
            rbEnemy.velocity = new Vector2(EnemySpeed, rbEnemy.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //sprite rotaciona para a direita.
        }
        else
        {
            //inimigo posicionado a direita do jogador. Se move para esquerda.
            rbEnemy.velocity = new Vector2(-EnemySpeed, rbEnemy.velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //sprite rotaciona para a esquerda.
        }

        if(transform.position.y < Player.position.y)
        {
            //inimigo posicionado abaixo do jogador. Se move para cima.
            rbEnemy.velocity = new Vector2(rbEnemy.velocity.x, EnemySpeed);
        }
        else
        {
            //inimigo posicionado acima do jogador. Se move para baixo.
            rbEnemy.velocity = new Vector2(rbEnemy.velocity.x, -EnemySpeed);
        }
    }

    void StopChasingPlayer()
    {
        rbEnemy.gravityScale = Mathf.Abs(Physics2D.gravity.y);
        //inimigo afetado novamente pela gravidade.

        rbEnemy.velocity = new Vector2(0, 0);
        //inimigo para de se mover.
    }

    private void OnCollisionStay2D(Collision2D other) //checa se ele está colidindo e causa dano.
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScript.Damage -= EnemyDPS * Time.deltaTime;
        }
    }

    private void OnCollisionExit2D(Collision2D other) // se player sai do contato, para de tomar dano.
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScript.Damage = 0.0f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Kill")
        {
            Destroy(gameObject);
        }
    }

    public void PlayerKilled()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
