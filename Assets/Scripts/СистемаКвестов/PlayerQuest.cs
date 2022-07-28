using System;
using System.Collections;
using System.Collections.Generic;
using DS;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;

public class PlayerQuest : MonoBehaviour
{
    private VIDE_Assign QuestDialog;
    [SerializeField] private GameObject DialogTransfer;
    [SerializeField] private Text questText;
    [SerializeField] private GameObject DialogTransfer2;
    [SerializeField] private Text questText2;
    [SerializeField] private DialogButtonTransfer questButt;
    [SerializeField] private GameObject sqipButt;
    private PLayerController pLayerController;

    private List<DialogButtonTransfer>questButtons = new List<DialogButtonTransfer>();
    private VD.NodeData data; 

    private void Start() 
    {
        pLayerController = gameObject.GetComponent<PLayerController>();    
    }

    public void SetChoice(int indexDialog)
    {
        ClearButtons();
        data.commentIndex = indexDialog;
        Sqip();
    }

    public void StartDialog(VIDE_Assign questDialog)
    {
        if (!VD.isActive)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            DialogTransfer.SetActive(true);
            DialogTransfer2.SetActive(false);
            VD.BeginDialogue(questDialog);
            Dialog();
            Debug.Log("страт");
        }
    }

    // private void OnTriggerExit(Collider other) 
    // {
    //     Debug.Log(other.name);
    //     DialogTransferOff();
    // }

    private void Dialog()
    {
        data = VD.nodeData;

        if (data.isPlayer) 
        {
            sqipButt.SetActive(false);
            CreateAnswer();
        }
        else
        {
            sqipButt.SetActive(true);
            questText.text = VD.nodeData.comments[VD.nodeData.commentIndex];
        }

        if (data.isEnd)
        {
            DialogEnd();
        }
         
    }

    public void Sqip()
    {
        VD.Next();
        Dialog();
    }

    private void DialogEnd()
    {
        VD.EndDialogue();
        DialogTransferOff();

        ClearButtons();
        GameManager.singleton.SetIsControlingPlayer(true);
        GameManager.singleton.SwithCameraEnabled(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DialogTransferOff()
    {
        DialogTransfer.gameObject.SetActive(false);
        Debug.Log("диалог закрыт");
    }
    private void ClearButtons()
    {
        foreach (var item in questButtons)
        {
            Destroy(item.gameObject);
        }
        questButtons.Clear();
    }

    public void CreateAnswer()
    {
        float offset = 20;
        
        for (int i = 0; i < data.comments.Length; i++)
        {
            DialogButtonTransfer buffer = Instantiate(questButt, DialogTransfer.transform);
            // buffer.Init(VD.nodeData.comments[i], i);
            questButtons.Add(buffer);

            buffer.gameObject.SetActive(true);
            buffer.transform.position += new Vector3(0,-40 * i + offset,0);

            data.commentIndex = i;
        }
    }
}
