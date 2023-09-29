using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardControl : MonoBehaviour
{

    public GameObject choicePanel; // 选择界面面板
    public List<Button> buttons; // 七个按钮的列表
    private List<Button> activeButtons; // 显示的三个按钮的列表

    private void Start()
    {
        choicePanel.SetActive(false); // 初始时禁用选择界面
        activeButtons = new List<Button>();
    }

    public void ShowChoicePanel()
    {
        choicePanel.SetActive(true);
        RandomlySelectButtons();
        Time.timeScale = 0;
    }

    public void RandomlySelectButtons()
    {
        // 随机选择三个按钮
        activeButtons.Clear();
        List<Button> availableButtons = new List<Button>(buttons);

        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, availableButtons.Count);
            Button selectedButton = availableButtons[randomIndex];
            activeButtons.Add(selectedButton);
            availableButtons.RemoveAt(randomIndex);
            selectedButton.gameObject.SetActive(true);
        }
    }

    public void HideChoicePanel()
    {
        choicePanel.SetActive(false);
        DeactivateButtons();
        Time.timeScale = 1;
    }

    public void DeactivateButtons()
    {
        foreach (Button button in activeButtons)
        {
            button.gameObject.SetActive(false);
        }
       
    }

    public void CollectBox()
    {

        ShowChoicePanel();
    }

   
}