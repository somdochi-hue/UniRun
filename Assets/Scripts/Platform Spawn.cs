using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platformPrefab;
    public int initCount = 5;
    public Transform spawnPoint;
    public GameObject[] platfroms;
    private int currentIndex = 0;
    public float  interval = 1f;

    public float spwanTimer = 0f;

    public GameManager gameManager;


    private void Start()
    {
        spwanTimer = interval;
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
        
        if (spwanTimer > interval)
        {
            spwanTimer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        platfroms[currentIndex].SetActive(false);
        platfroms[currentIndex].transform.position = spawnPoint.position;
        platfroms[currentIndex].SetActive(true);

        currentIndex = (currentIndex +1) % platfroms.Length;
    }
}
