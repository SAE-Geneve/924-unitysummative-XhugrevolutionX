using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private float lifeSpan = 20f;

    private float _timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
