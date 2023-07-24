using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // ** 레벨 선택으로 해당 씬으로 이동할 씬 페이더
    public SceneFader fader;

    // ** 레벨 버튼을 관리할 배열
    public Button[] levelButtons;

    private void Start()
    {
        // ** 초기 최종 레벨을 1로 설정
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        // ** 최종 레벨보다 높은 레벨을 모두 비활성화
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    // ** 레벨 선택 시 해당 레벨로 씬 이동
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
