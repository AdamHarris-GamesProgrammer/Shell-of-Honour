//libraries
using UnityEngine;
using UnityEngine.SceneManagement;

//class for button actions in the main menu user interface
public class MainMenuButtonHandler : MonoBehaviour
{
    //represents the button objects in the main menu
    public GameObject PlayButton;
    public GameObject HelpButton;
    public GameObject QuitButton;
    public GameObject HelpMenu;
    public GameObject HelpMenuExitButton;

    //plays the game scene when the play button is pressed
    public void PlayButtonPressed() {
        SceneManager.LoadScene("MainLevel");
    }

    //quits the game when the quit button is pressed
    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    //displays the help menu when the help button is pressed
    public void HelpButtonPressed()
    {
        HelpMenu.SetActive(true);
        HelpMenuExitButton.SetActive(true);
    }

    //exits the help menu when the exit help button is pressed
    public void HelpMenuExitPressed()
    {
        HelpMenu.SetActive(false);
        HelpMenuExitButton.SetActive(false);
    }

}
