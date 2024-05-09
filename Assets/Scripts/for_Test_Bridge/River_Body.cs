using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River_Body : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {           
        if (other.gameObject.tag == "player")
            other.gameObject.GetComponent<Player>().Show_Boat(true);
    }

    private void OnTriggerExit(Collider other)
    {       
        if (other.tag == "player")
            other.gameObject.GetComponent<Player>().Show_Boat(false);        
    }
}
