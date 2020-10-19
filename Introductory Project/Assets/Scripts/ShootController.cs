using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float fireRate = .2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    float timeUntilFire;
    movement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<movement>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
