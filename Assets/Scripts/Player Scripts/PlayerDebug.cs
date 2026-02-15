using UnityEngine;

public class PlayerDebug : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Player EXISTS at start! Position: " + transform.position);
        Debug.Log("Player name: " + gameObject.name);
        Debug.Log("Player parent: " + (transform.parent != null ? transform.parent.name : "None"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Player Position: " + transform.position);
            Debug.Log("Player Active: " + gameObject.activeSelf);
        }
    }

    void OnDestroy()
    {
        Debug.LogError("PLAYER WAS DESTROYED!");
        Debug.LogError("Destroyed by: " + UnityEngine.StackTraceUtility.ExtractStackTrace());
    }

    void OnDisable()
    {
        Debug.LogWarning("PLAYER WAS DISABLED!");
    }
}
