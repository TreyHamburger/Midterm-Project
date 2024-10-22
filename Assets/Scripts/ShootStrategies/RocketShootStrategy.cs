using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShootStrategy : IShootStrategy
{
    ShootInteractor interactor;
    Transform shootPoint;

    public RocketShootStrategy(ShootInteractor _interactor)
    {
        Debug.Log("Switched to rocket mode");
        this.interactor = _interactor;
        shootPoint = interactor.GetShootPoint();

        //change gun colour
        interactor.gunRenderer.material.color = interactor.bulletColor;
    }

    public void Shoot()
    {
        PooledObject pooledObj = interactor.rocketPool.GetPooledObject();
        pooledObj.gameObject.SetActive(true);


        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rocket = pooledObj.GetComponent<Rigidbody>();
        rocket.transform.position = shootPoint.position;
        rocket.transform.rotation = shootPoint.rotation;

        rocket.velocity = shootPoint.forward * interactor.GetShootVelocity();

        //Destroy(bullet.gameObject, 5.0f);
        interactor.rocketPool.DestroyPooledObject(pooledObj, 5);
    }
}
