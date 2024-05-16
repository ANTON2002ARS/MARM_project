using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Switch_Scenes_GM : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private GameObject image_manual;
    [SerializeField] private List<Image> list_Manual;
    [SerializeField] private int active_number;

    private void Start()
    {        
        if (MouseLook.Sensitivity == 0)
            MouseLook.Sensitivity = 250;
        image_manual.SetActive(false);
    }
    public static void Test_Bridge()
    {
        GameManager.With_River = false;
        SceneManager.LoadScene("Test_Bridge");
    }
    public static void Test_Bridge_With_river()
    {
        GameManager.With_River = true;
        SceneManager.LoadScene("Test_Bridge");        
    }

    public static void Enginnering_Intelligence()
    {
        SceneManager.LoadScene("Enginnering_Intelligence_Build");
    }
    public static void Test_Search()
    {
        G_M.Is_Test = true;
        Overview_bridge();
    }

    public static void Overview_bridge()
    {
        SceneManager.LoadScene("Overview_bridge");
    }

    public static void Menu_Scene()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu_Scene");
    }

    public void Open_Manual_PDF()
    {
         

    }

    public void Rurn_list(bool forward)
    {
        if (forward)
            active_number++;
        else
            active_number--;
        if (active_number < 0)
            active_number = 0;
        if (active_number > list_Manual.Count)
            active_number = list_Manual.Count - 1;
    }

    public void Show_Side_Manual()
    {
        for (int i = 0; i < list_Manual.Count; i++)
        {
            if (i == active_number)
                list_Manual[i].enabled = true;
            else
                list_Manual[i].enabled = false;
        }
    }

    public void Open_Manual() => image_manual.SetActive(!image_manual.activeSelf);
    public void Exit_game() => Application.Quit();

    public void Speed_Change_Mouse()
    {
        float speed = scrollbar.value * 1000;
        if (speed < 1) speed = 1;
        MouseLook.Sensitivity = speed;        
    }
}
