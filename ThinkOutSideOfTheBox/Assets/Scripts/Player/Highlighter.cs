using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Highlighter : MonoBehaviour
{
    [SerializeField] private TMP_Text helpText;
    [SerializeField] private GameObject highlighterInfo;
    [SerializeField] private string helpTextIntro;

    // Start is called before the first frame update
    void Start()
    {
        highlighterInfo.SetActive(false);
    }

    public void StartInfo(string _text)
    {
        highlighterInfo.SetActive(true);
        setText(_text);
    }
    public void StopInfo()
    {
        highlighterInfo.SetActive(false);
    }


    public void setText(string _text)
    {
         
       helpText.text = $"{_text}";
        
       
    }
}
