using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static int score = 0;
    private GUIStyle style;
    public static bool is_end = false;
    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI() {
        if (is_end) {
            GUI.Label(new Rect(Screen.width / 4, Screen.height / 4, 200, 100), "Game Over, your score is : " + score, style);
        } else {
            GUI.Label(new Rect(Screen.width / 10, Screen.height / 10, 200, 100), "Score: " + score, style);
        }
    }
}
