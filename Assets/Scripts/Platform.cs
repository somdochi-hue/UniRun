using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; // 장애물이 들어갈 자리를 만들어줌.
    public float obstaclesRatio = 0.3f; // 장애물을 30프로의 확률로 활성화 시켜줌.
    private bool stepped = false;

    public int score = 10;
    private GameManager gameManager;

    private void Start()
    {
        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();
    }

    private void OnEnable()  // 활성화 문법.
    {
        stepped = false;

        foreach (GameObject obstacle in obstacles)
        {
            // obstacle.SetActive(Random.value < obstaclesRatio); 아래 코드와 동일.
            obstacle.SetActive(Random.Range(0f, 1f) < obstaclesRatio);
            // 0~1까지를 무작위로 뽑아서 0.3 밑으로 나오면 장애물이 활성화
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !stepped)
        {
            stepped = true;
            gameManager.AddScore(score);
        }
    }
}   
