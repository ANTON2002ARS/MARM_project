using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject player;
    [SerializeField] private MouseLook mouselook;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            canvas.gameObject.SetActive(true);
            mouselook.can_rotation = false;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            mouselook.can_rotation = true;
        }
        
    }
}
