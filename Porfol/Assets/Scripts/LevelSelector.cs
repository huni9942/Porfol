using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // ** ���� �������� �ش� ������ �̵��� �� ���̴�
    public SceneFader fader;

    // ** ���� ��ư�� ������ �迭
    public Button[] levelButtons;

    private void Start()
    {
        // ** �ʱ� ���� ������ 1�� ����
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        // ** ���� �������� ���� ������ ��� ��Ȱ��ȭ
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    // ** ���� ���� �� �ش� ������ �� �̵�
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
