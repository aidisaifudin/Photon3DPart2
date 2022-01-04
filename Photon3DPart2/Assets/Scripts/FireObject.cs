using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class FireObject : MonoBehaviourPun
{
    public GameObject Bullet;
    public float Force = 2000f;
    public PhotonView pV;
    // Start is called before the first frame update
    void Start()
    {
        pV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject BulletHolder;
            BulletHolder = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;

            BulletHolder.transform.Rotate(Vector3.left * 90);

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = BulletHolder.GetComponent<Rigidbody>();
            Temporary_RigidBody.AddForce(transform.forward * Force);

            Destroy(BulletHolder, 5.0f);
        }
    }
}
