using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/TitleScreen")]
public class TitleScreen : MonoBehaviour
{

    void OnGUI()
    {
        // ���ִ�С
        GUI.skin.label.fontSize = 48;

        // UI���Ķ���
        GUI.skin.label.alignment = TextAnchor.LowerCenter;

        // ��ʾ����
        GUI.Label(new Rect(0, 30, Screen.width, 100), "SpaceWar");


        // ��ʼ��Ϸ��ť
        if (GUI.Button(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.7f, 200, 30), "Game Start"))
        {
            // ��ʼ��ȡ��һ��
            Application.LoadLevel("level1");
        }
    }
}
