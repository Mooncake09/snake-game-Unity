using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Food : MonoBehaviour
{
   // [SerializeField] private GameObject food;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SnakeController snake = collision.GetComponent<SnakeController>();
        if (collision != null)
        {
            Destroy(this.gameObject);
        }
    }
}
