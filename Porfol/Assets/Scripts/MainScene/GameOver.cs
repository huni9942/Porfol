using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // ** ���� �ؽ�Ʈ
    public Text roundsText;

    // ** ���θ޴� �̸�
    public string menuSceneName = "MainMenu";

    // ** �� ���̴�
    public SceneFader sceneFader;

    // ** ���� ���� ��, ���� �ؽ�Ʈ�� ���� ���带 ���ڿ�ȭ �Ѵ�
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    // ** ��õ� ��ư Ŭ�� ��, ���� Ȱ��ȭ �Ǿ��ִ� ���� �ٽ� �ҷ��´�
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    // ** �޴� ��ư Ŭ�� ��, ���� �޴��� �̵��Ѵ�
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
