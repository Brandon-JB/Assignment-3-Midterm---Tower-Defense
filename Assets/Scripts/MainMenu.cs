using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject Buttons;
    public GameObject BackButton;
    public GameObject Credit;
    public GameObject Path;

    private void Start()
    {
        Instruction.SetActive(false);
        Buttons.SetActive(true);
        Credit.SetActive(false);
        BackButton.SetActive(false);
        Path.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level");
    }

    public void Instructions()
    {
        Instruction.SetActive(true);
        Buttons.SetActive(false);
        BackButton.SetActive(true);
        Path.SetActive(false);
    }

    public void Credits()
    {
        Buttons.SetActive(false);
        BackButton.SetActive(true);
        Credit.SetActive(true);
        Path.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        Buttons.SetActive(true);
        Instruction.SetActive(false);
        BackButton.SetActive(false);
        Credit.SetActive(false);
        Path.SetActive(true);
    }
}
