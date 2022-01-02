using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class EnemyTarget : MonoBehaviour
{
    public float health = 100f;
    public GameObject deadbody;
    private bool created = false;
    public float damage = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            EnemyTarget target = collision.transform.gameObject.GetComponent<EnemyTarget>();
            target.ApplyDamage(damage);
        }
      
    }
    [PunRPC]
public void ApplyDamage(float amount)
    {
        health -= Mathf.Abs(amount);
        if (health < 0 )
        {

            Destroy(gameObject);
        }
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("ApplyDamage", RpcTarget.All);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
