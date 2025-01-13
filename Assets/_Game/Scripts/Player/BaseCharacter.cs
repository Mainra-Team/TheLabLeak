using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
	public virtual void EnableCharacter()
	{
		// Logika default saat karakter diaktifkan
		Debug.Log($"{gameObject.name} enabled.");
	}

	public virtual void DisableCharacter()
	{
		// Logika default saat karakter dinonaktifkan
		Debug.Log($"{gameObject.name} disabled.");
	}
}