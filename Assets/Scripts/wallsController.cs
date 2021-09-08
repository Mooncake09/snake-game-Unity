using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wallsController : MonoBehaviour
{
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

        if (snake != null)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
