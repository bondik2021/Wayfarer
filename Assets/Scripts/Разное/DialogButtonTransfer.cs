using DS;
using UnityEngine;
using UnityEngine.UI;

public class DialogButtonTransfer : MonoBehaviour
{
    [SerializeField] private Text textButt;
    private PlayerQuest playerQuest;
    [SerializeField] private int indexDialog;
    private DSDialogue Dialogue;

    private void Start() 
    {
        playerQuest = FindObjectOfType<PlayerQuest>();
    }
    public void Init(string textMess, int index, DSDialogue dSDialogue)
    {
        textButt.text = textMess;
        indexDialog = index;
        Dialogue = dSDialogue;
    }
    public void SetChoice()
    {
        Dialogue.SetChoice(indexDialog);
    }
    
}
