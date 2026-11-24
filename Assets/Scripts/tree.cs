using UnityEngine;
using Unity.Mathematics;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class tree : MonoBehaviour
{
    public GameObject item;
    public GameObject slider;
    public Spawner spawner;
    public float ShakeSpeed = 25f;
    public float ShakeAmmount = 0.08f;
    public float ShakeTime = 0.15f;
    public float colorRecoverySpeed = 5f;
    private bool hasDroppedWood, direction;
    private float gradient = 1f;
    private SpriteRenderer spriteRenderer;
    private Transform originalPosition;
    private Transform sliderTransform;
    private Vector3 basePosition;
    private Coroutine shakeCoroutine;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalPosition = transform;
        sliderTransform = slider.transform;
        basePosition = originalPosition.position;
    }
    void Update()
    {
    gradient = Mathf.MoveTowards(gradient, 1, colorRecoverySpeed * Time.deltaTime);
    spriteRenderer.color = new Color(1,gradient,gradient,1);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
         if (hasDroppedWood||!collision.CompareTag("Weapon") || !collision.GetComponent<Cursor>().breaksTrees) return;
        slider.gameObject.SetActive(true);
       if(direction) direction = false;
        if(slider.transform.localScale.x > 0.1f) return;
        hasDroppedWood = true;
        spawner.validTilePositions.Add(spawner.Tilemap.WorldToCell(transform.position - Vector3.up * 0.25f));
        GameObject ObjectClone = Instantiate(item, transform.position, quaternion.identity);
        ObjectClone.SetActive(true);
        Destroy(gameObject);
    }
    public void sliderDamage(float damage)
    {
        Vector3 scale = sliderTransform.localScale;
        scale.x = Mathf.Max(0f, scale.x - damage/100);
        StartCoroutine(ShakeForseconds());
        sliderTransform.localScale = scale;

        gradient = 0f;
        StartShake();
    }
    private void StartShake()
    {
         if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);
            originalPosition.position = basePosition;
            direction =!direction;
            shakeCoroutine = StartCoroutine(ShakeForseconds());
    }
    private IEnumerator ShakeForseconds()
    {
        float elapsed = 0f;
        float sign = direction ? 1f : -1f;

        while (elapsed < ShakeTime)
        {
            elapsed += Time.deltaTime;
            float fade = 1f - (elapsed / ShakeTime);
            float offset = Mathf.Sin(elapsed * ShakeSpeed) * ShakeAmmount * fade;
            originalPosition.position = basePosition + Vector3.right * offset * sign;
            yield return null;
        }

        originalPosition.position = basePosition;
        shakeCoroutine = null;
    }
    }