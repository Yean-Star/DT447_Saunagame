using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponent;
    [SerializeField]
    private TextMeshProUGUI nameTextComponent;
    [SerializeField]
    private string[] linesFirst;
    [SerializeField]
    private float textSpeed;

    private int index;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        nameTextComponent.text = getName();
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == linesFirst[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = linesFirst[index];
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    public void StartDialogueAgain()
    {
        if(count > 0)
        {
            StartDialogue();
        }
        else
        {
            return;
        }
        
        
    }
    IEnumerator TypeLine()
    {
        foreach(char c in linesFirst[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void setName(string name)
    {
        nameTextComponent.text = name;
    }
    string getName()
    {
        return nameTextComponent.text;
    }
    void NextLine()
    {
        if(index < linesFirst.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            count++;
            index = 0;
            textComponent.text = string.Empty;
        }
    }
  
}
