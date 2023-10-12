using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molly4 : MonoBehaviour
{
    public GameObject[] prefabHole = new GameObject[3];

    void Start()
    {
        RandomMolly();
    }
    public void RandomMolly()
    {
        GameObject _prefab;
        int rand = Random.Range(0, 3);
        //int rand = 0;
        switch (rand)
        {
            case 0: _prefab = prefabHole[rand];break;
            case 1: _prefab = prefabHole[rand];break;
            case 2: _prefab = prefabHole[rand];break;
            default: _prefab = prefabHole[0];break;
        }
        
        Instantiate(_prefab, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
