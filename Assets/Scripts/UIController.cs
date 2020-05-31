using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text FinalText;
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    List<Image> LifeImagesList;
    [SerializeField]
    GameObject Menu;
    bool isMenuTurn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!isMenuTurn)
            {
                TurnOnMenu();
            }
        }
    }

    private void TurnOnMenu()
    {
        Menu.SetActive(true);
        isMenuTurn = true;
        GameController.Instance.PauseGame();
    }

    public void TurnOffMenu()
    {
        Menu.SetActive(false);
        isMenuTurn = false;
        GameController.Instance.ContinueGame();
    }

    public void UpdateScoreText(int score)
    {
        ScoreText.text = string.Format("Score: {0}", score);
    }

    public void UpdateLifeImageList(int currentLifes)
    {
        for (int i = LifeImagesList.Count; i > currentLifes; i--)
        {
            LifeImagesList[i - 1].gameObject.SetActive(false);
        }
    }
    public void ShowWinText()
    {
        FinalText.gameObject.SetActive(true);
        FinalText.text = "YOU WIN!";
    }

    public void ShowLoseText()
    {
        FinalText.gameObject.SetActive(true);
        FinalText.text = "YOU LOSE!";
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
