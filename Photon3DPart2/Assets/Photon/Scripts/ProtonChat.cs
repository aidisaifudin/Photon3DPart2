using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using TMPro;
using System.Text.RegularExpressions;

public class ProtonChat : MonoBehaviour
{
    public TMP_InputField ChatInput;
    public TextMeshPro ChatContent;
    private PhotonView photon;
    private List<string> messages = new List<string>();
    private float buildDelay = 0f;
    private int maximumMessages = 14;
  
    // Start is called before the first frame update
    void Start()
    {
        photon = GetComponent<PhotonView>();
    }

    [PunRPC]
    void RPC_AddMessage(string msg)
    {
        messages.Add(msg);
    }
    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            ChatContent.maxVisibleLines = maximumMessages;

            if (messages.Count > maximumMessages)
            {
                messages.RemoveAt(0);
            }
            if (buildDelay < Time.time)
            {
                BuildChatContent();
                buildDelay = Time.time + 0.25f;
            }

        }else if(messages.Count>0)
        {
            messages.Clear();
            ChatContent.text = "";
        }
    }
    public void SendChat(string msg)
    {
        string NewMessages = PhotonNetwork.NickName + ": " + msg;
        photon.RPC("RPC_AddNewMessages", RpcTarget.All, NewMessages);

    }
    public void SubmitChat()
    {
        string blankCheck = ChatInput.text;
        blankCheck = Regex.Replace(blankCheck, @"\s", "");
        if (blankCheck == "")
        {
            ChatInput.ActivateInputField();
            ChatInput.text = "";
            return;
        }
        SendChat(ChatInput.text);
        ChatInput.ActivateInputField();
        ChatInput.text = "";
    }
    void BuildChatContent()
    {
        string NewContents = "";
        foreach(string s in messages)
        {
            NewContents += s + "\n";
        }
        ChatContent.text = NewContents;
    }
}
