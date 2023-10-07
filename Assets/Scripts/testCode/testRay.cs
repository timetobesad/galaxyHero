using UnityEngine;

public class testRay : MonoBehaviour
{
    private void Update()
    {
        Ray r = new Ray(transform.position, new Vector3(-1, 0, 0));
        RaycastHit hit;

        if (Physics.Raycast(r, out hit, 1))
        {
            Debug.DrawRay(r.origin, r.direction, Color.yellow, 3);
        }

       
    }
}
