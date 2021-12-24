using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using System.Text.RegularExpressions;

public class ProtonChat : MonoBehaviour
{
    public TMP_InputField ChatInput;
    public TextMeshProUGUI ChatContent;
    private PhotonView _photon;
    private List<string> _messages = new List<string>();
    private float _buildDelay = 0f;
    private int _maximumMessages = 14;
  
    // Start is called before the first frame update
    void Start()
    {
        _photon = GetComponent<PhotonView>();
    }

    
     protected virtual void RPC_AddNewMessage(string msg)
    {
        _messages.Add(msg);
    }
    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            ChatContent.maxVisibleLines = _maximumMessages;

            if (_messages.Count > _maximumMessages)
            {
                _messages.RemoveAt(0);
            }
            if (_buildDelay < Time.time)
            {
                BuildChatContent();
                _buildDelay = Time.time + 0.25f;
            }

        }else if(_messages.Count>0)
        {
            _messages.Clear();
            ChatContent.text = "";
        }
    }
    public void SendChat(string msg)
    {
        string NewMessages = PhotonNetwork.NickName + ": " + msg;
        _photon.RPC("RPC_AddNewMessages", RpcTarget.All, NewMessages);

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
        foreach(string s in _messages)
        {
            NewContents += s + "\n";
        }
        ChatContent.text = NewContents;
    }
}
