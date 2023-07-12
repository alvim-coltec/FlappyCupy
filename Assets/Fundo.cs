using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundo : MonoBehaviour
{
    [SerializeField] private Texture2D[] textures;
    private int currentTextureIndex = 0;
    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    public float textureChangeInterval = 0.5f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (textures.Length > 0)
        {
            spriteRenderer.sprite = Sprite.Create(textures[currentTextureIndex], new Rect(0, 0, textures[currentTextureIndex].width, textures[currentTextureIndex].height), Vector2.one * 0.5f);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= textureChangeInterval)
        {
            ChangeTexture();
            timer = 0f;
        }
    }

    private void ChangeTexture()
    {
        currentTextureIndex++;
        if (currentTextureIndex >= textures.Length)
        {
            currentTextureIndex = 0;
        }

        spriteRenderer.sprite = Sprite.Create(textures[currentTextureIndex], new Rect(0, 0, textures[currentTextureIndex].width, textures[currentTextureIndex].height), Vector2.one * 0.5f);
    }
}
