using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera air_camera;
    [SerializeField] private GameObject player;
    [SerializeField] private Text Status_game;

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
    private void Start()
    {
        air_camera.enabled = true;
        player.SetActive(false);
    }
    private  void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            StartCoroutine(Chenge_View());   
    }
    private void Full_Test()
    {
        StartCoroutine(Chenge_View());
        Status_game.text = "Мост не построен";
        Status_game.color = Color.red;
    }
    private void Pass_Test()
    {
        StartCoroutine(Chenge_View());
        Status_game.text = "Мост построен";
        Status_game.color = Color.green;
    }

    
    private IEnumerator Chenge_View()
    {
        if (player.activeSelf)
        {            
            air_camera.enabled = true;
            player.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            player.SetActive(true);
            air_camera.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        float delayTime = 0.2f; // Задержка в секундах
        yield return new WaitForSeconds(delayTime);
        /*player.SetActive(!air_camera.enabled);
        air_camera.enabled = player.activeSelf;*/
    }

    public void Continue_game() => StartCoroutine(Chenge_View());

    public void Restart_game()
    {
        foreach (var item in Status_Action)
        {
            Debug.Log(item.Name_Action);
        }
    }
    
    public void Exit_game() => Application.Quit();
}
