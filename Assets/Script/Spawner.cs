using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Pipes prefab;
    public float initialSpawnRate = 1f; // 初始生成頻率（秒）
    //public float minSpawnRate = 0.5f;   // 最低生成頻率，確保不會太快
    public float spawnDecreaseRate = 0.05f; // 每 10 秒降低的生成間隔
    public float minHeight = 10f; // 管道生成的最低高度
    public float maxHeight = 18f;  // 管道生成的最高高度
    public float verticalGap = 3f; // 管道上下之間的間距
    public float spawnTime = 2;
    float timer = 0;
    private float currentSpawnRate; // 當前的管道生成間隔時間
    [SerializeField] private GameManager GameManager;

    private void Start()
    {
        
    }

    // 生成管道的方法
    private void Spawn()
    {
        Pipes pipes = Instantiate(prefab, transform.position, Quaternion.identity); // 建立新的管道
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); // 隨機調整管道高度
    }

    private void Update()
    {
        if (GameManager.isGameOver) return;

        timer += Time.deltaTime;
        if (timer >= spawnTime) 
        {
            timer = 0f;
            Spawn();
        }
    }
}
