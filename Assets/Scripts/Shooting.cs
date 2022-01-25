using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Shooting : MonoBehaviour
{
    public GameObject theObject;
    public GameObject objectStartingPosition;

    public float objectSpeed = 2f;
    public bool objectReset = true;

    public GameObject explosionEffect;

    public AudioSource tankFireSource;
    public AudioClip tankFireClip;
    public float tankFireVolume = 0.5f;

    public AudioSource explosionSource;
    public AudioClip explosionClip;
    public float explosionVolume = 0.5f;

    public void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Commie")
        {
            ScoreManager.instance.AddScore();
            Explosion();
            explosionSource.PlayOneShot(explosionSource.clip, explosionVolume);
            Debug.Log("Commie Hit");
            objectReset = true;
        }
    }

    void Update()
    {

        if (objectReset == true)
        {
            theObject.transform.position = objectStartingPosition.transform.position;
            transform.rotation = Quaternion.identity;
        }


        if (Input.GetKeyDown("space"))
        {
            objectReset = false;
        }

        //tank fire sound
        if (Input.GetKeyDown("space") && objectReset == false)
        {
            tankFireSource.PlayOneShot(tankFireSource.clip, tankFireVolume);
        }

        //fires up
        transform.Translate(Vector3.up * Time.deltaTime * objectSpeed);

        if (theObject.transform.position.y > 20)
        {
            objectReset = true;
        }
    }

    public void Explosion()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

}
