using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerSetup : MonoBehaviourPunCallbacks
{

    [SerializeField]
    GameObject FPSCamera;

    [SerializeField]
    TextMeshProUGUI playerNameText;

    public float damage;
    public float health;
    // Start is called before the first frame update
    void Start()
    {

        if (photonView.IsMine)
        {
            transform.GetComponent<MovementController>().enabled = true;
            FPSCamera.GetComponent<Camera>().enabled = true;
        }
        else
        {
            transform.GetComponent<MovementController>().enabled = false;
            FPSCamera.GetComponent<Camera>().enabled = false;
        }


        SetPlayerUI();

    }

    void SetPlayerUI()
    {
        if (playerNameText!=null)
        {
            playerNameText.text = photonView.Owner.NickName;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("I got hit");
            ApplyDamage();

        }
    }
    public void ApplyDamage()
    {
        health -= Mathf.Abs(damage);
        if (health < 0)
        {
            SceneManager.LoadScene("Defeat");
            
        }
    }
 

}
