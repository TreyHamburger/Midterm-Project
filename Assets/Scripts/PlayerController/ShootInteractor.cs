using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [SerializeField] private Input inputType;

    [Header("Gun")]
    public MeshRenderer gunRenderer;
    public Color bulletColor;
    public Color rocketColor;
    
    [Header("Shoot")]
    public ObjectPool bulletPool;
    public ObjectPool rocketPool;

    [SerializeField] private float shootForce;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private PlayerMoveBehaviour playerMoveBehaviour;

    private float finalShootVelocity;
    private IShootStrategy currentStrategy;


    public override void Interact()
    {
        if(currentStrategy == null)
        {
            currentStrategy = new BulletShootStrategy(this);
        }

        if(input.weapon1Pressed)
        {
            currentStrategy = new BulletShootStrategy(this);
        }
        if(input.weapon2Pressed)
        {
            currentStrategy = new RocketShootStrategy(this);
        }
        //Shoot strategy
        if (input.primaryShootPressed && currentStrategy != null)
        {
            currentStrategy.Shoot();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void Shoot()
    {
        PooledObject pooledObj = objPool.GetPooledObject();
        pooledObj.gameObject.SetActive(true);


        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledObj.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * finalShootVelocity;

        //Destroy(bullet.gameObject, 5.0f);
        objPool.DestroyPooledObject(pooledObj, 5);
    }*/

    public Transform GetShootPoint()
    {
        return shootPoint;
    }

    public float GetShootVelocity()
    {
        finalShootVelocity = playerMoveBehaviour.GetForwardSpeed() + shootForce;
        return finalShootVelocity;
    }
}
