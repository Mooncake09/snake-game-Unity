using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject foodPrefab;
    private Vector3 pos;
    private GameObject _food;
    // Start is called before the first frame update
    void Start()
    {
        //pos = new Vector3(0, 1.1f , 0);
        //Instantiate(food, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (_food == null)
        {
            pos = new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(-1.6f, 1.6f), 0.0f);
            _food = Instantiate(foodPrefab) as GameObject;
            _food.transform.position = pos;
        }
    }
}
