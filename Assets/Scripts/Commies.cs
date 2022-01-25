using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commies : MonoBehaviour
{
    public GameObject Commie;
    public GameObject commieStartingPosition;

    public int commieSpeed = 5;
    public bool commieReset = true;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * commieSpeed);


        if (tag == "Commie" && transform.position.y <= 0)
        {
            Commie.transform.position = commieStartingPosition.transform.position;
            ScoreManager.instance.TakeAwayLife();

        }
    }


    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Cannon")
        {
            Commie.transform.position = commieStartingPosition.transform.position;
        }

    }
}
