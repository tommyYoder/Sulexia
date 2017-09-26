using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
  
    public GameObject playerExplosion;

    

    public int scoreValue;
    private GameController gameController;

    void Start()
    { 
    GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }


        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Bolt")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "EnemyBolt")
        {
         
            Destroy(gameObject);
        }

       

            if (other.tag == "Player")
        {
            gameController.SubLive();
            if (gameController.gameOver == true)
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
                Destroy(other.gameObject);
            }
        }

        gameController.AddScore(scoreValue);
        
        Destroy(gameObject);
    }
}
