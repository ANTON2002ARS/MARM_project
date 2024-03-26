using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    [HideInInspector] public List<Action_build> Status_Action; 

    private int Max_Mistakes = 10;
    private int _currentMistakes = 0;
    public int Mistakes
    {
        get => _currentMistakes;
        set
        {
            _currentMistakes = value;
            if (_currentMistakes >= Max_Mistakes)
                Full_Test();            
        }
        
    }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    private void Full_Test()
    { 
        Debug.Log("Тест провален");
    }
    private void Pass_Test()
    {

    }
}
