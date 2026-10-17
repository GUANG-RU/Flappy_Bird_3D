using UnityEngine;

public class Pipes : MonoBehaviour
{

    [SerializeField] private float pipeSpeed;
    [SerializeField] private float Edge;
    [SerializeField] private GameManager GameManager;

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (GameManager.isGameOver) return;

        // 使管道向左移動
        transform.Translate(Vector3.forward * pipeSpeed * Time.deltaTime);

        /*// 隨機讓管道產生微小變動，使遊戲更具挑戰性
        if (transform.position.x > 1 && Random.value <= 0.3f)
        {
            SuddenMove();
        }*/

        // 如果管道移動到螢幕左側邊界，則刪除以節省記憶體
        if (transform.position.z <= Edge)
        {
            Destroy(gameObject);
        }
    }
}
