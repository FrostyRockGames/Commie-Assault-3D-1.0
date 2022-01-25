using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float PlayerSpeed = 5;

    void Update()
    {

        if (Input.GetKeyDown("left shift") && Input.GetKeyDown("a"))
        {
            PlayerSpeed = 10;
        }
        else
        {
            PlayerSpeed = 5;
        }
        float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * amtToMove, Space.World);
    }

    

}

  


