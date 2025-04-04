using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Canvas learn_canvas;
    [SerializeField] private Image image_text;
    [SerializeField] private Text learn_text;
    [SerializeField] private GameObject folder;
    [SerializeField] private Camera camera_player;
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _speedRun;
    [SerializeField] private GameObject Boat;
    [SerializeField] private TMP_Text text_Task;
    [SerializeField] private TMP_Text text_Error;     
    [SerializeField] private GameObject Scroll_View;
    [SerializeField] private GameObject Content;
    [SerializeField] private GameObject String_text;    

    private CharacterController _characterController;
    private Vector3 _walkDirection;
    private Vector3 _velocity;
    private float _speed;
    public static Player Instance_P { get; private set; }
    private void Awake() => Instance_P = this;
    private void Start()
    {
        _speed = _speedWalk;
        _characterController = GetComponent<CharacterController>();
        Close_Learn_Text();
        text_Task.enabled = false;
        text_Error.enabled = false;
        Scroll_View.SetActive(false);
    }

    private void Update()
    {
        Jump(Input.GetKey(KeyCode.Space) && _characterController.isGrounded);
        Run(Input.GetKey(KeyCode.LeftShift));
        Sit(Input.GetKey(KeyCode.LeftControl));
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        _walkDirection = transform.right * x + transform.forward * z;
        // Для закрытие текста у игрока нажатие Е \\
        if (Input.GetKey(KeyCode.E))
        {
            Close_Learn_Text();
            Scroll_View.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
        
    private void FixedUpdate()
    {
        Walk(_walkDirection);
        DoGravity(_characterController.isGrounded);
    }

    public void Show_List_Mistake(List<Mistake_build> list_mistakes)
    {
        Cursor.lockState = CursorLockMode.None;
        RectTransform contentRectTransform = Content.GetComponent<RectTransform>();
        Transform Tramsform_Content = Content.GetComponent<Transform>();
        foreach (Transform item in Tramsform_Content)
            Destroy(item.gameObject);
        
        learn_canvas.enabled = true;
        Scroll_View.SetActive(true);        
        Instantiate(String_text, Content.transform);   
        var analysis = Instantiate(String_text, Content.transform);
        analysis.GetComponent<Text>().text = "АНАЛИЗ ПРОЛЕТОВ МОСТА";
        var analysis_text = Instantiate(String_text, Content.transform);
        analysis_text.GetComponent<Text>().text = "Список не установленый элементов:";

        float Height = 35f;
        contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, contentRectTransform.sizeDelta.y + Height*3);

        foreach (Mistake_build itemText in list_mistakes)
        {
            GameObject Item = Instantiate(String_text, Content.transform);
            Item.GetComponent<Text>().text = itemText.Mistake;            
            contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, contentRectTransform.sizeDelta.y + Height);
        }
    }     

    public void Show_Learn_Text_Image(string text, GameObject image_madel)
    {
        learn_canvas.enabled = true;
        image_text.enabled = true;
        learn_text.text = text;
        // Если не нужно то без модели \\
        if (folder.transform.childCount == 1)
            Destroy(folder.transform.GetChild(0).gameObject);
        if (image_madel == null)
            return;
        GameObject Image = Instantiate(image_madel);
        Image.transform.localPosition = Vector3.zero;
        Image.transform.SetParent(folder.transform, false);
    }

    public void Show_Image( GameObject image_madel)
    {
        learn_canvas.enabled = true;
        image_text.enabled = false;
        // Если не нужно то без модели \\
        if (folder.transform.childCount == 1)
            Destroy(folder.transform.GetChild(0).gameObject);
        if (image_madel == null)
            return;
        GameObject Image = Instantiate(image_madel);
        Image.transform.localPosition = Vector3.zero;
        Image.transform.SetParent(folder.transform, false);
    }

    public void Show_Task(string tag)
    { 
        string text = "Нажмите на: ";
        if (tag == null)
            text_Task.enabled = false;
        else
            text_Task.enabled = true;
        text_Task.text = text + tag;
    }

    public void Show_Error(bool is_error)
    {
        text_Error.enabled = true;
        if (is_error)
        {
            text_Error.text = "НЕ ПРАВИЛЬНО";
            text_Error.color = Color.red;
        }
        else
        {
            text_Error.text = " ПРАВИЛЬНО";
            text_Error.color = Color.green;
        }
        Invoke("Close_text_Error", 2f);
    }

    public void Show_Error(string text)
    {
        text_Error.enabled = true;
        text_Error.text = text;
        text_Error.color = Color.black;
        Invoke("Close_text_Error", 2f);
    }

    private void Close_text_Error() => text_Error.enabled = false;
    private void Close_Learn_Text() => learn_canvas.enabled = false;

    private void Walk(Vector3 direction)
    {
        _characterController.Move(direction * _speedWalk * Time.fixedDeltaTime);
    }

    private void DoGravity(bool isGrounded)
    {
        if (isGrounded && _velocity.y < 0)
            _velocity.y = -1f;
        _velocity.y -= _gravity * Time.fixedDeltaTime;
        _characterController.Move(_velocity * Time.fixedDeltaTime);
    }

    private void Jump(bool canJump)
    {
        if (canJump)
            _velocity.y = _jumpPower;
    }

    private void Run(bool canRun)
    {
        _speedWalk = canRun ? _speedRun : _speed;
    }

    private void Sit(bool canSit)
    {
        _characterController.height = canSit ? 1f : 2f;
    }

    public void Show_Boat(bool is_show) 
    {
        if(GameManager.With_River)
            Boat.SetActive(is_show);
        else if(SceneManager.GetActiveScene().name == "Enginnering_Intelligence_Build")
            Boat.SetActive(is_show);       
    }
}