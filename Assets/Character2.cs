using UnityEngine;

public class Character2 : BaseCharacter
{
	public override void EnableCharacter()
	{
		base.EnableCharacter();
		// Logika khusus untuk Character1
		Debug.Log("Character1 is ready to play!");
	}

	public override void DisableCharacter()
	{
		base.DisableCharacter();
		// Logika khusus saat Character1 dinonaktifkan
		Debug.Log("Character1 is no longer active.");
	}
}