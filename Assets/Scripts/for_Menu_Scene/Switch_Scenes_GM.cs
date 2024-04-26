using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Switch_Scenes_GM : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private GameObject image_manual;

    private void Start()
    {        
        if (MouseLook.Sensitivity == 0)
            MouseLook.Sensitivity = 250;
        image_manual.SetActive(false);
    }
    public static void Test_Bridge()
    {
        SceneManager.LoadScene("Test_Bridge");
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

    public void Open_Manual() => image_manual.SetActive(!image_manual.activeSelf);
    public void Exit_game() => Application.Quit();

    public void Speed_Change_Mouse()
    {
        float speed = scrollbar.value * 1000;
        if (speed < 1) speed = 1;
        MouseLook.Sensitivity = speed;        
    }
}
