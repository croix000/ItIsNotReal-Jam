using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject StartUI;
    [SerializeField]
    private GameObject GameOverUI;
    [SerializeField]
    private GameObject WinUI;

    [SerializeField]
    private TextMeshProUGUI MedkitsLabel;

    private int MedkitsCount=0;
    [SerializeField]
    private int MaxMedkitsCount;

    public InputAction restartAction;
    private bool isGameOver;
    public InputAction myAction;


    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    private AudioClip pickupSound;


    [SerializeField]
    private AudioClip winSound;


    [SerializeField]
    private AudioClip loseSound;

    private void Awake()
    {
        Instance = this;
        myAction = new InputAction(binding: "/*/<button>");
        myAction.performed += HideStartUI;
        myAction.Enable();


        restartAction.performed += RestartGame;
    }

    // Start is called before the first frame update
    void Start()
    {

        StartUI.SetActive(true);
        Time.timeScale = 0f;
        MedkitsLabel.text = "Meds " + MedkitsCount.ToString() + '/' + MaxMedkitsCount.ToString();
    }


    public void MedPickUp() {

        GetComponent<AudioSource>().PlayOneShot(pickupSound);
        MedkitsCount++;

        MedkitsLabel.text = "Meds "+MedkitsCount.ToString()+'/'+ MaxMedkitsCount.ToString();

        if (MedkitsCount >= MaxMedkitsCount)
            ShowWinUI();

    }

    void OnEnable()
    {
        restartAction.Enable();
    }
    void OnDisable()
    {
        restartAction.Disable();

    }
    public void ShowGameOver() {

        GetComponent<AudioSource>().PlayOneShot(loseSound);
        Time.timeScale = 0f;
        isGameOver =true;
        GameOverUI.SetActive(true);
    }

    public void ShowWinUI() {

        GetComponent<AudioSource>().PlayOneShot(winSound);

        Time.timeScale = 0f;
        isGameOver = true;
        WinUI.SetActive(true);
    }

    public void HideStartUI(InputAction.CallbackContext context) {

        Time.timeScale = 1f;
        StartUI.SetActive(false);
        myAction.performed -= HideStartUI;
        myAction.Disable();
    }


    public void RestartGame(InputAction.CallbackContext context) {

        if (!isGameOver)
            return;
        SceneManager.LoadScene(0);

    }

}
