using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int initCount = 5;
    public Transform spawnPoint;
    public float yRange = 2f;
    public GameObject[] platfroms;
    private int currentIndex = 0;
    public float  interval = 1f;
    public float  intervalRange = 0.25f;
    private float currentInterval;
    public float spwanTimer = 0f;

    public GameManager gameManager;


    private void Start()
    {
        currentInterval = Random.Range(-intervalRange, intervalRange);
        spwanTimer = currentInterval;
    }
    private void Awake()
    {
        platfroms = new GameObject[initCount];
        for (int i = 0; i < platfroms.Length; i++)
        {
            platfroms[i] = Instantiate(platformPrefab);
            platfroms[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (gameManager.IsGameOver)
        {
            return;
        }
        
        spwanTimer += Time.deltaTime;
        
        if (spwanTimer > currentInterval)
        {
            spwanTimer = 0f;
            currentInterval = interval + Random.Range(-intervalRange, intervalRange);
            Spawn();
        }
    }

    private void Spawn()
    {
        platfroms[currentIndex].SetActive(false);

        Vector3 point = spawnPoint.position;
        point.y += Random.Range(-yRange, yRange);

        platfroms[currentIndex].transform.position = point;
        platfroms[currentIndex].SetActive(true);

        currentIndex = (currentIndex +1) % platfroms.Length;
    }
}
