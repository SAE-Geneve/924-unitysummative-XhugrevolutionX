using System.Security.Cryptography;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    [SerializeField] private HUD hud;
    
    private int _score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Box Delivered");
            
            Destroy(collision.gameObject);
            _score++;
            hud.SetScore(_score);
        }
    }
}
