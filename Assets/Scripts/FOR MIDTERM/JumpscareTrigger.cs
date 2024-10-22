using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    
    public Transform player; // Reference to the player's transform
    public float detectionDistance = 5f; // Distance at which jumpscare is triggered
    public GameObject jumpscarePrefab; // Prefab for the jumpscare effect
    public float jumpscareDuration = 5f; // Duration to replace position

    private GameObject jumpscareInstance; // Store the instantiated jumpscare

    private void Update()
    {
        // Calculate distance to the player
        float distance = Vector3.Distance(player.position, transform.position);

        // Check if the player is within detection distance
        if (distance <= detectionDistance)
        {
            // Check if the player is looking at the object
            if (IsPlayerLookingAt())
            {
                TriggerJumpscare();
            }
        }
    }

    private bool IsPlayerLookingAt()
    {
        // Calculate the direction from the player to the jumpscare object
        Vector3 directionToTarget = (transform.position - player.position).normalized;

        // Check if the angle between player's forward direction and the direction to the target is small enough
        float angle = Vector3.Angle(player.forward, directionToTarget);
        return angle < 30f; // Adjust this value to make the jumpscare more or less sensitive
    }

    private void TriggerJumpscare()
    {
        // Check if the jumpscare has already been instantiated
        if (jumpscareInstance == null)
        {
            // Instantiate the jumpscare prefab
            jumpscareInstance = Instantiate(jumpscarePrefab, transform.position, Quaternion.identity);

            // Replace the position of this GameObject with the jumpscare's position
            transform.position = jumpscareInstance.transform.position;

            // Make the jumpscare face the player
            Vector3 directionToPlayer = player.position - jumpscareInstance.transform.position;
            jumpscareInstance.transform.rotation = Quaternion.LookRotation(directionToPlayer);

            // Start the coroutine to handle the duration
            StartCoroutine(JumpscareDuration());
        }
    }

    private IEnumerator JumpscareDuration()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(jumpscareDuration);

        // Restore the original position of the detector (optional)
        // transform.position = originalPosition; // Uncomment this line if you want to restore to an original position
        // Destroy the jumpscare instance
        Destroy(jumpscareInstance);
    }
}
