using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    public float pistonSpeed = 5f;
    public float maxPistonDistance = 2f;

    private bool isLeftPistonExtending = false;
    private bool isRightPistonExtending = false;
    private bool isUpPistonExtending = false;
    private bool isDownPistonExtending = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        HandlePistonMovement();
    }

    void HandleInput()
    {
        isLeftPistonExtending = Input.GetKey(KeyCode.A);
        isRightPistonExtending = Input.GetKey(KeyCode.D);
        isUpPistonExtending = Input.GetKey(KeyCode.W);
        isDownPistonExtending = Input.GetKey(KeyCode.S);
    }

    void HandlePistonMovement()
    {
        if (isLeftPistonExtending || isRightPistonExtending || isUpPistonExtending || isDownPistonExtending)
        {
            ExtendAndRetractPiston(isLeftPistonExtending, "LeftPiston");
            ExtendAndRetractPiston(isRightPistonExtending, "RightPiston");
            ExtendAndRetractPiston(isUpPistonExtending, "UpPiston");
            ExtendAndRetractPiston(isDownPistonExtending, "DownPiston");
        }
    }

    void ExtendAndRetractPiston(bool shouldExtend, string pistonName)
    {
        Debug.Log($"Extending {pistonName}: {shouldExtend}");

        Transform piston = transform.Find(pistonName);

        if (piston != null)
        {
            float distanceToMove = piston.localScale.y * 0.5f;
            float newPosition;

            if (shouldExtend)
            {
                newPosition = Mathf.Min(piston.localPosition.z + pistonSpeed * Time.fixedDeltaTime, maxPistonDistance);
            }
            else
            {
                newPosition = Mathf.Max(piston.localPosition.z - pistonSpeed * Time.fixedDeltaTime, -maxPistonDistance);
            }

            piston.localPosition = new Vector3(piston.localPosition.x, piston.localPosition.y, newPosition);
            //Debug.Log($"Piston: {pistonName}, New Position: {piston.localPosition}");

        }
    }
}
