using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;

    public float obstaclesRatio = 0.3f;
    private void OnEnable()  // 활성화 문법.
    {
        foreach (GameObject obstacle in obstacles)
        {
            // obstacle.SetActive(Random.value < obstaclesRatio); 아래 코드와 동일.
            obstacle.SetActive(Random.Range(0f, 1f) < obstaclesRatio);
        }
    }
}
