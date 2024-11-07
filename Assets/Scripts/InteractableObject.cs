using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string objectName;
    private GameManager gameManager;

    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    private void OnMouseDown()
    {
        if (gameManager != null)
        {
            gameManager.InteractWithObject(objectName);
        }
    }
}

