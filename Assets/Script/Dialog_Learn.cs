using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog_Learn : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;
    
    public GameObject DialogPannel;
    public GameObject continueButton;
    public GameObject cameraTrigger;
    public AudioSource typywords;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence() {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            typywords.Play();
            StartCoroutine(Type());
            
        }
        else {
            textDisplay.text = "";
            continueButton.SetActive(false);
            DialogPannel.GetComponent<DiaLogGUIControl>().closedialogGUI();
            cameraTrigger.GetComponent<MagnetCameraTrigger>().closeScaleCamera();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
            typywords.Stop();
            continueButton.GetComponent<Button>().Select();
        }
    }
}
