using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameManager.Instance.GoToMainMenu();
    }
}