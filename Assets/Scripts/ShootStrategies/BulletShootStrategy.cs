using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootStrategy : IShootStrategy
{
    ShootInteractor interactor;
    Transform shootPoint;


    public BulletShootStrategy(ShootInteractor _interactor)
    {
        Debug.Log("Switched to bullet mode");
        this.interactor = _interactor;
        shootPoint = interactor.GetShootPoint();

        //Change the colour of the gun
        interactor.gunRenderer.material.color = interactor.bulletColor;
    }
    public void Shoot()
    {
        PooledObject pooledObj = interactor.bulletPool.GetPooledObject();
        pooledObj.gameObject.SetActive(true);


        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledObj.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * interactor.GetShootVelocity();

        //Destroy(bullet.gameObject, 5.0f);
        interactor.bulletPool.DestroyPooledObject(pooledObj, 5);
    }
}
