using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    // Thêm một nút Button cho script này trong Inspector của Unity
    public Button exitButton;

    void Start()
    {
        // Gắn sự kiện OnClick cho nút Button
        exitButton.onClick.AddListener(ExitGame);
    }

    // Hàm xử lý việc thoát game
    void ExitGame()
    {
#if UNITY_EDITOR
        // Nếu đang trong chế độ Editor, sử dụng EditorApplication.Exit()
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Nếu không phải chế độ Editor, sử dụng Application.Quit()
        Application.Quit();
#endif
    }




}



