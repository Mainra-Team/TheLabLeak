using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GameObject[] characterObjects; // Referensi ke child objek
	private BaseCharacter[] characterScripts;               // Referensi ke script masing-masing karakter
	private int activeCharacterIndex = 0;                   // Indeks karakter aktif

	private void Awake()
	{
		// Inisialisasi array script berdasarkan objek
		characterScripts = new BaseCharacter[characterObjects.Length];
		for (int i = 0; i < characterObjects.Length; i++)
		{
			characterScripts[i] = characterObjects[i].GetComponent<BaseCharacter>();
		}
	}

	private void Start()
	{
		ActivateCharacter(activeCharacterIndex);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCharacter(0);
		if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCharacter(1);
		if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchCharacter(2);
	}

	private void SwitchCharacter(int characterIndex)
	{
		if (characterIndex < 0 || characterIndex >= characterObjects.Length || characterIndex == activeCharacterIndex)
			return;

		// Nonaktifkan karakter saat ini
		DeactivateCharacter(activeCharacterIndex);

		// Aktifkan karakter baru
		ActivateCharacter(characterIndex);
	}

	private void ActivateCharacter(int characterIndex)
	{
		characterObjects[characterIndex].SetActive(true);
		characterScripts[characterIndex].EnableCharacter();
		activeCharacterIndex = characterIndex;
	}

	private void DeactivateCharacter(int characterIndex)
	{
		characterScripts[characterIndex].DisableCharacter();
		characterObjects[characterIndex].SetActive(false);
	}
}