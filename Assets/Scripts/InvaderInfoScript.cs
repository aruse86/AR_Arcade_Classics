// needed namespace for Unity to function
using UnityEngine;

// Defines an InvaderInfo class that holds a point value for a specific invader when it is shot
public class InvaderInfo : MonoBehaviour
{
    public int pointValue = 10; // Default value, change per invader prefab in the inspector window
}