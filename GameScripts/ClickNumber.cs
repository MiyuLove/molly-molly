using System.Collections;
using UnityEngine;

public class ClickNumber : MonoBehaviour
{
    public float speed = 0f;
    private float x, y;
    void Awake()
    {
        Application.targetFrameRate = 50;
    }

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        y += speed;
        transform.position = new Vector2(x, y);
    }
}
