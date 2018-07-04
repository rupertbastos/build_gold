using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSkinAnimation : MonoBehaviour {

    public string spriteSheetName = "idle_18";

    private void LateUpdate()
    {
        Debug.LogWarning("entrou");

        var subSprites = Resources.LoadAll<Sprite>("idle - color 01/" + spriteSheetName);

        Debug.LogWarning(subSprites.Length);

        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            Debug.LogWarning("Entrou 2");
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
            {
                Debug.LogWarning("Entrou 3");
                renderer.sprite = newSprite;
            }
        }
    }
}
