using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    [Header("UI References: ")]
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private TextMeshProUGUI uiWinnerText;
    [SerializeField] private Button uiRestartButton;

    [Header("Board Reference: ")]
    [SerializeField] private Board board;

    // Start is called before the first frame update
    void Start()
    {
        uiRestartButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        board.OnWinAction += OnWinEvent;

        uiCanvas.SetActive(false);
    }

    private void OnWinEvent(Mark mark, Color color)
    {
        uiWinnerText.text = mark.ToString() + " Wins";
        uiWinnerText.color = color;

        uiCanvas.SetActive(true);
    }

    private void OnDestroy()
    {
        uiRestartButton.onClick.RemoveAllListeners();
        board.OnWinAction -= OnWinEvent;
    }
}
