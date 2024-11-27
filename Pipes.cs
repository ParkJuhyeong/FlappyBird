using UnityEngine;

public class Pipes : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public float speed = 5f;
    public float gap = 3f;

    private float leftEdge;

    private void Awake()
    {
        // top과 bottom Transform을 자식 오브젝트에서 찾기
        top = transform.Find("Top");
        bottom = transform.Find("Bottom");

        if (top == null || bottom == null)
        {
            Debug.LogError("TopPipe 또는 BottomPipe가 할당되지 않았습니다.");
        }
    }

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;

        // gap에 따라 파이프 위치 조정
        top.position += Vector3.up * gap / 2;
        bottom.position += Vector3.down * gap / 2;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
