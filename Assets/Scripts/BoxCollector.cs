using System.Security.Cryptography;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    [SerializeField] BoxValues[] boxValues;
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


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Debug.Log("Box Delivered");
            
            Destroy(other.gameObject);

            switch (other.gameObject.name)
            {
                case "BoxSmall(Clone)":
                    _score += boxValues[0].value;
                    break;
                case "BoxLong(Clone)":
                    _score += boxValues[1].value;
                    break;
                case "BoxWide(Clone)":
                    _score += boxValues[2].value;
                    break;
                case "BoxLarge(Clone)":
                    _score += boxValues[3].value;
                    break;
            }
            
            hud.SetScore(_score);
        }
    }
}
