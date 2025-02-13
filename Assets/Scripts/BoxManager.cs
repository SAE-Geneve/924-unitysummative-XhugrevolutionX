using System.Collections;
using TMPro;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField] private Conveyor[] conveyors;
    [SerializeField] private GameObject[] boxesPrefabs;
    [SerializeField] private Transform[] dispenderPoints;
    [SerializeField] private float spawnDelay = 3f;
    [SerializeField] private int nbBoxLimit = 10;

    private Coroutine _coroutine;

    private int _conveyorID;
    private bool _boxCanSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _conveyorID = 0;
        _boxCanSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < nbBoxLimit)
        {
            if (_boxCanSpawn)
            {
                if (!conveyors[_conveyorID]._hasABox)
                {
                    Instantiate(boxesPrefabs[Random.Range(0, 4)], dispenderPoints[_conveyorID].position, Quaternion.identity, transform);
                    if (_conveyorID >= conveyors.Length - 1)
                    {
                        _conveyorID = 0;
                    }
                    else
                    {
                        _conveyorID++;
                    }

                    _boxCanSpawn = false;
                }

                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _coroutine = StartCoroutine("BoxSpawnDelay");
            }
        }
    }

    IEnumerator BoxSpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        _boxCanSpawn = true;
    }
}