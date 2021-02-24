using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public GameObject explosionFactory;
    public GameObject hitFactory;
    public float rate = 3;
    public int hp = 1;
    public float speed = 5;
    private int randValue;

    void Start()
    {
        randValue = UnityEngine.Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("Player");
        float y = transform.position.y - target.transform.position.y; 
        if(randValue < rate && y >= 3)
        {
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }

        transform.position += dir * speed * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision other)
    {
        hp--;
        if(hp <= 0) {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;

            gameObject.SetActive(false);
            EnemyManager.enemyObjectpool.Add(gameObject);

            ScoreManager.Instance.Score++;
        }
        else 
        {
            GameObject hit = Instantiate(hitFactory);
            hit.transform.position = transform.position;
        }

        if(other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(other.gameObject);
        }
        else if(other.gameObject.name.Contains("Player")) {
            Destroy(other.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
