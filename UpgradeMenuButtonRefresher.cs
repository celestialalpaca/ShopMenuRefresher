using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuButtonRefresher : MonoBehaviour
{
    public List<Button> allButtons; // List of all buttons

    public GameObject buttonPanel; // The panel containing the buttons
    public int numberOfButtonsToShow = 4; // Number of buttons to show
    public Button refreshButton; // The refresh button

    public Button rangeBuff;


    private void Start()
    {
        Refresh(); // Initial randomization and display

        // Attach the Refresh function to the refreshButton's click event
        refreshButton.onClick.AddListener(Refresh);

    }

    // Shuffle the button list using Durstenfeld Shuffle (Fisher-Yates Shuffle)
    private void ShuffleButtons()
    {
        for (int i = allButtons.Count - 1; i > 0; i--)
        {



            int j = Random.Range(0, i + 1);
            Button temp = allButtons[i];
            allButtons[i] = allButtons[j];
            allButtons[j] = temp;

        }
    }

    // Show the next set of buttons in the shuffled list

    private void ShowNextButtons(int startIndex)
    {
        for (int i = 0; i < allButtons.Count; i++)
        {
            if (i >= startIndex && i < startIndex + numberOfButtonsToShow)
            {
                allButtons[i].gameObject.SetActive(true);
            }
            else
            {
                allButtons[i].gameObject.SetActive(false);
            }
        }
    }



    // Refresh button click event handler
    private void Refresh()
    {


        foreach (Button button in allButtons)
        {
            if (button.interactable)
            {
                button.gameObject.SetActive(false);
            }



        }

        ShuffleButtons();
        ShowNextButtons(0);
    }
    public void rangeBuffLock()
    {
        //rangebufff.interactable = !rangebufff.interactable; // Toggle interactability
        rangeBuff.interactable = !rangeBuff.interactable; // Toggle interactability



    }

}