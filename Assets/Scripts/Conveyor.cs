using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField] private float conveyorSpeed = 5;
    public bool _hasABox;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hasABox = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            _hasABox = false;
        }
    }
    
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            _hasABox = true;
            collision.gameObject.transform.position += transform.forward * conveyorSpeed * Time.deltaTime;
        }
    }
}
