using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Teclando ESC saira do Jogo, mas somente no executavel e nao dentro do editor
        if (Input.GetKeyDown(KeyCode.Escape))
        {        
            Application.Quit();
        }
       
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ClicarJogar()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ClicarIntroducao()
    {
        SceneManager.LoadScene("Introduction");
          }

    public void ClicarCreditos()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ClicarSair()
    {
        Application.Quit();
    }

}
