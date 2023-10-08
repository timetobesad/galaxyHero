using UnityEngine;

public class AirDefRocket : MonoBehaviour
{
    public float speed;
    private GameObject target;

    private bool isSetTarget = false;

    public string[] enemyTags;

    private void Update()
    {
        if (!isSetTarget || target == null) return;

        transform.TransformDirection(target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider coll)
    {
        foreach (string tag in enemyTags)
            if (tag == coll.tag)
                destEnemyRocket(coll.gameObject);
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
        isSetTarget = true;
    }

    private void destEnemyRocket(GameObject rocket)
    {
        Destroy(rocket);
        Destroy(gameObject);
    }
}
