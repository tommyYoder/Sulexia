using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {


  
    public AudioSource ShieldHitSound;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.tag == "Enemy")
        {
            ShieldHitSound.Play();
          
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}
