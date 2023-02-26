using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public enum CharacterTypes { Player1, Player2, Player3 };
    public List<GameObject> characters = new List<GameObject>();
    public List<GameObject> playerPrefabs = new List<GameObject>();
    public GameObject currentCharacter;
    public CharacterTypes currentCharacterType;

    void Awake()
    {
        // Add the player prefabs to the characters list
        foreach (GameObject prefab in playerPrefabs)
        {
            characters.Add(prefab);
        }

        // Instantiate the initial character
        currentCharacterType = CharacterTypes.Player1;
        InstantiateCharacter((int)currentCharacterType);
    }

    // Instantiate a character at the position of the current GameObject
    public void InstantiateCharacter(int index)
    {
        if (characters[index] == null)
            return;
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }
        currentCharacter = Instantiate(characters[index], transform);
        currentCharacter.transform.localPosition = Vector3.zero;
        currentCharacter.transform.localRotation = Quaternion.identity;
        currentCharacter.name = characters[index].name;
        currentCharacterType = (CharacterTypes)index;
        CharacterType();
    }

    // Swap to the next character in the list
    public void SwapCharacter()
    {
        int nextCharacterType = (int)(currentCharacterType + 1) % characters.Count;
        InstantiateCharacter(nextCharacterType);
    }

    // prints in console which character is switched to
    public void CharacterType()
    {
        switch (currentCharacterType)
        {
            case CharacterTypes.Player1:
                Debug.Log("I'm player1");
                break;
            case CharacterTypes.Player2:
                Debug.Log("I'm player2");
                break;
            case CharacterTypes.Player3:
                Debug.Log("I'm player3");
                break;
        }
    }
}

