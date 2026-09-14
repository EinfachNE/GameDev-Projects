using UnityEngine;

public class AssociatesUIManager : MonoBehaviour
{

    public void OpenAssociatesUI()
    {
        gameObject.SetActive(true);
    }
    public void CloseAssociatesUI()
    {
        gameObject.SetActive(false);

    }
}
