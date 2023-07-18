using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // ** ���� �ؽ�Ʈ
    public Text roundsText;

    // ** ���� ���� ��, ���� �ؽ�Ʈ�� ���� ���带 ���ڿ�ȭ �Ѵ�
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    // ** ��õ� ��, ���� Ȱ��ȭ �Ǿ��ִ� ���� �ٽ� �ҷ��´�.
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {

    }
}
