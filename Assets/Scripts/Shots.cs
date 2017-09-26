using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shots : MonoBehaviour {

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
