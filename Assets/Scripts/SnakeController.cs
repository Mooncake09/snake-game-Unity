using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using TreeEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public float speed = 1f;
    private bool horizontal = true;
    private bool vertical = false;
    //private GameObject[] snakeTails = new GameObject[100];
    List<Transform> snakeTails = new List<Transform>();
    private Vector2 vector;
    private Vector2 moveVector;
    private bool isEated = false;
    [SerializeField] private GameObject snakeTail;

    private Vector2 position = new Vector2(0f, 0f);
    private Vector2 moveDirection = new Vector2(0f, 0f);
    private float timer;
    private float maxTimer = 1f;

    [SerializeField] private TextMesh scoreLabel;
    private float scoreCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer; 
        InvokeRepeating("Move", 0.3f, speed);
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.A) && horizontal)
        {
            //vector = new Vector2(-speed * Time.deltaTime, 0);
            vector = -Vector2.right;
            horizontal = false;
            vertical = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && horizontal)
        {
            //vector = new Vector2(speed * Time.deltaTime, 0);
            vector = Vector2.right;
            horizontal = false;
            vertical = true;
        }
        else if (Input.GetKeyDown(KeyCode.W) && vertical)
        {
            //vector = new Vector2(0, speed * Time.deltaTime);
            vector = Vector2.up;
            horizontal = true;
            vertical = false;
        }
        else if (Input.GetKeyDown(KeyCode.S) && vertical)
        {
            //vector = new Vector2(0, -speed * Time.deltaTime);
            vector = -Vector2.up;
            horizontal = true;
            vertical = false;
        }

         moveVector = vector / 5f;
    }

    private void Move()
    {
        if (isEated)
        {
            //if (speed > 0.002)
            //{
            //    speed -= 0.002f;
            //}
            GameObject tail = Instantiate(snakeTail, transform.position, Quaternion.identity);
            snakeTails.Insert(0, tail.transform);
            isEated = false;
        }

        else if (snakeTails.Count > 0)
        {
            snakeTails.Last().position = transform.position;
            snakeTails.Insert(0, snakeTails.Last());
            snakeTails.RemoveAt(snakeTails.Count - 1);
        }
        transform.Translate(moveVector);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Food food = collision.GetComponent<Food>();

        if(food != null)
        {
            isEated = true;
            scoreCounter++;
            scoreLabel.text = "Score: " + scoreCounter;
        }
    }

}
