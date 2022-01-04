using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullete : MonoBehaviourPun
{
    public float speed = 10f;
    public float destroyTime = 2f;

    IEnumerator destroyBullete()
    {
        yield return new WaitForSeconds(destroyTime);
        this.GetComponent<PhotonView>().RPC("DestroyItem", RpcTarget.AllBuffered);

    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    [PunRPC]

    public void DestroyItem()
    {
        Destroy(this.gameObject);
    }


}
