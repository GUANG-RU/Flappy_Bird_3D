using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    [SerializeField] private float Edge;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float Offset;
    [SerializeField] private GameManager GameManager;

    private void Update()
    {
        if (GameManager.isGameOver) return;

        transform.Translate(Vector3.forward*moveSpeed* Time.deltaTime);

        if (transform.position.z <= Edge)
        {
            transform.position += new Vector3(0, 0, Offset);
        }
    }

}
