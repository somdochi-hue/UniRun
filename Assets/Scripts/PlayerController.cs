using UnityEngine;

// 점프 뛰기 / 위로 속도를 가지게 한다. => Rigidbody의 속도를 설정한다.
// 애니메이션 제어
// 죽음 처리

public class PlayerController : MonoBehaviour
{
    [Header("점프 기능")]
    [SerializeField] Rigidbody2D rigid;  // 직접 레퍼러싱(Inspector 창에서 직접 넣어주기)
    [SerializeField] [Range(0, 20f)] float jumpSpeed; // Range: Inspector 창에 스크롤 생성.
    [SerializeField] AudioSource jumpSound;
    [SerializeField] bool isGrounded;
    [SerializeField] int jumpCount;
    [Header("애니메이션")]
    [SerializeField] Animator animator;
    [Header("게임 오버")]
    [SerializeField] AudioSource dieSound;
    private GameManager gameManager;

    // [SerializeField] : 외부에서 공개X / 밖에서 수정 불가능 / 유니티에서 수정 가능.

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameObject findGO = GameObject.FindWithTag("GameController");
        gameManager = findGO.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") &&
            jumpCount <= 1)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigid.linearVelocityY = jumpSpeed;
        jumpSound.Play();
        jumpCount++;
    }

        public void Die()
    {
        animator.SetTrigger("Die");
        rigid.linearVelocity = Vector2.zero;
        rigid.simulated = false;
        dieSound.Play();
        gameManager.OnPlayerDead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            jumpCount = 0;
            animator.SetBool("Grounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            animator.SetBool("Grounded", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dead")
        {
            Die();
        }
    }
}
