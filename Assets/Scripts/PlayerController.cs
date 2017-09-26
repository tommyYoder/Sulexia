using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject Shield;
    public GameObject Player;
    public GameObject Player1;
    public GameObject Player2;

    public GameObject shot;
    public GameObject shot1;
    public GameObject shot2;
  

    public Transform shotSpawn;
    public Transform shotSpawn1;
    public Transform shotSpawn2;

    public float fireRate;

    public AudioSource PowerUpSound;
    public AudioSource ShieldSound;
    public AudioSource ShieldHitSound;
    
    private float nextFire;

   

    void Start()
    {
      
        Player.GetComponent<MeshCollider>().enabled = true;
        Shield.SetActive(false);
        Player1.SetActive(false);
        Player2.SetActive(false);
        shot1.SetActive(false);
        shot2.SetActive(false);


    }

     void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot1, shotSpawn1.position, shotSpawn.rotation);
            Instantiate(shot2, shotSpawn2.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
            
        }
    }



void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f,GetComponent<Rigidbody>().velocity.x * -tilt);
    }
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp")
        {
         if (GetComponent<Collider>() != null)
            Player.GetComponent<MeshCollider>().enabled = false;
            Shield.SetActive(true);
            Destroy(other.gameObject);
            ShieldSound.Play();
            ShieldSound.SetScheduledEndTime(AudioSettings.dspTime + (8f - 0f));
            yield return new WaitForSeconds(8f);
            Player.GetComponent<MeshCollider>().enabled = true;
            Shield.SetActive(false);
        }

        if (other.gameObject.tag == "FireShot")
        {
            if (GetComponent<Collider>() != null)
            fireRate = .1f;
            PowerUpSound.Play();
            Destroy(other.gameObject);
            yield return new WaitForSeconds(5f);
            fireRate = .25f;

        }
        if (other.gameObject.tag == "Ship")
        {
         
            Player1.SetActive(true);
            Player2.SetActive(true);
            shot1.SetActive(true);
            shot2.SetActive(true);
            PowerUpSound.Play();
            Destroy(other.gameObject);
            yield return new WaitForSeconds(5f);
            shot1.SetActive(false);
            shot2.SetActive(false);
            Player1.SetActive(false);
            Player2.SetActive(false);
        }
    } 

}
