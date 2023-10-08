using UnityEngine;

public class testMovement : MonoBehaviour
{
    public float defSpeed = 1;
    public float speedRotate = 1;
    public float speedMove = 1;

    public float timeTurn = 2;

    private void Start()
    {
        Invoke("resetTurn", timeTurn);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            setSpeedRotate(-defSpeed);

        if (Input.GetKeyDown(KeyCode.E))
            setSpeedRotate(defSpeed);

        transform.Translate(new Vector3(speedRotate, 0, -speedMove) * Time.deltaTime);
    }

    private void resetTurn()
    {
        speedRotate = 0;
    }

    private void setSpeedRotate(float speed)
    {
        speedRotate = speed > 0 ? Mathf.Abs(speed) : -Mathf.Abs(speed);
        Invoke("resetTurn", timeTurn);
    }
}