using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linecount : MonoBehaviour
{
    public TMPro.TMP_Text lineNumbersUI;
    public Text code;
    
    
    public void LineNum()
    {
        // code = GetComponent<Text>();
        code.text = "this is a very extremely super duper incredibly unbelievably very long sentence";
        Canvas.ForceUpdateCanvases();
        for (int i = 0; i < code.cachedTextGenerator.lines.Count; i++) {
            int startIndex = code.cachedTextGenerator.lines[i].startCharIdx;
            int endIndex = (i == code.cachedTextGenerator.lines.Count - 1) ? code.text.Length 
                : code.cachedTextGenerator.lines[i + 1].startCharIdx;
            int length = endIndex - startIndex;
            Debug.Log(code.text.Substring(startIndex, length));
        }
    }
}
