using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Rigidbody2D box;
    public float strength;
    public float ran = 20;
    public float ground = -10;
    public float top = 20;
    public GameObject boxPrefab;
    public float spawnInterval = 5;
    private float spawnTimer = 0;
    private bool hasCollided = false;
    private logicscript logic;
    private static int collisionCount = 0;
    public static bool gameover = false;
    public AudioSource collisionSound;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
        Vector3 start = new Vector3(Random.Range(-ran, ran), top, 0);
        transform.position = start;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollided = true;
        if (collision.gameObject.CompareTag("ground"))
        {
            collisionCount++;
        }

        collisionSound.Play();

        logic.addscore();

        if (collisionCount > 1)
        {
            collisionCount = 0;
            logic.gameover();
            gameover = true;
        }
        
    }
    void Update()
    {
        if (!hasCollided)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                box.velocity = Vector2.left * strength;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                box.velocity = Vector2.right * strength;
            }
        }

        spawnTimer += Time.deltaTime;

        if (!gameover && spawnTimer >= spawnInterval && transform.position.y < ground)
        {
            SpawnBox();
            spawnTimer = 0;
        }

    }

    private void SpawnBox()
    {
        Instantiate(boxPrefab, new Vector3(Random.Range(-ran, ran), top, 0), Quaternion.identity);
    }
}
