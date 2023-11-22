using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explosionPrefab;
    public GameObject miniExplosionPrefab;
    public int enemyLives;
    public int objectType;

    // Start is called before the first frame update
    void Start()
    {
        if (objectType == 1)
        {
            enemyLives = 1;
        }
        else if (objectType == 2)
        {
            enemyLives = 3;
        }
    }

        // Update is called once per frame
    void Update()
        {

        }

    public void LoseLife()
        {
            enemyLives--;
        }

    private void OnTriggerEnter2D(Collider2D whatIHit)
        {
            if (whatIHit.tag == "Player")
                {
                whatIHit.GetComponent<Player>().LoseLife();
                enemyLives--;
                GameObject.Find("GameManager").GetComponent<GameManager>().LifeLost(-1);
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                if (enemyLives <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
            else if (whatIHit.tag == "Weapon")
            {
            enemyLives--;
            if (enemyLives <= 0) {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(whatIHit.gameObject);
                Destroy(this.gameObject);

                if (objectType == 1)
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(2);
                }
                else if (objectType == 2)
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(4);
                }
                }
                else
                {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(whatIHit.gameObject);
            }
            }
        }
    }
