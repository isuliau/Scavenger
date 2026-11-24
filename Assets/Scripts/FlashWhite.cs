using System.Collections;
using UnityEngine;

public class FlashWhite : MonoBehaviour
{

    //this is NOT my code, I have no idea how any of this works, but since unity uses multiply for colors I had to use external code for flashing white for items
    [SerializeField] private SpriteRenderer targetRenderer;
    public item item;
    [SerializeField] private float whiteDuration = 0.01f;
    [SerializeField] private float returnDuration = 0.5f;
    [SerializeField] private Material whiteMaterial;
    private Material originalMaterial;
    private Material flashMaterial;
public bool onstart; 

    void Awake()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = targetRenderer.sharedMaterial;
        flashMaterial = new Material(whiteMaterial);
        if (onstart)StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        targetRenderer.sharedMaterial = flashMaterial;
        flashMaterial.SetFloat("_FlashAmount", 1f);

        yield return new WaitForSeconds(whiteDuration);

        float elapsed = 0f;
        while (elapsed < returnDuration)
        {
            elapsed += Time.deltaTime;
            flashMaterial.SetFloat("_FlashAmount", 1f - elapsed / returnDuration);
            yield return null;
        }

        targetRenderer.sharedMaterial = originalMaterial;
        if(item != null) item.touched = true;
    }

    private void OnDestroy()
    {
        if (flashMaterial != null)
            Destroy(flashMaterial);
    }
    }
