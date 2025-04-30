using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Button switchButton;
    [SerializeField] private TextMeshProUGUI switchText;

    [SerializeField] private string buttonSwitchText = "Switch to type: ";

    private int currentIndex = 0;

    void Start()
    {
        SetWeapon(0);
        switchButton.onClick.AddListener(SwitchWeapon);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(t.position);
            weapons[currentIndex].RotateToTouch(touchPos);
            weapons[currentIndex].HandleTouch(t);
        }
    }

    void SwitchWeapon()
    {
        weapons[currentIndex].gameObject.SetActive(false);
        currentIndex = (currentIndex + 1) % weapons.Length;
        SetWeapon(currentIndex);
    }

    void SetWeapon(int index)
    {
        weapons[index].gameObject.SetActive(true);
        weapons[index].transform.rotation = Quaternion.Euler(Vector2.zero);

        int nextIndex = (index + 1) % weapons.Length;
        switchText.text = buttonSwitchText + (nextIndex + 1);
    }
}
