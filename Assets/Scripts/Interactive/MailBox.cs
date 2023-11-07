using UnityEngine;
using Utilities;

public class MailBox : Interactive
{
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;
    [SerializeField]private Sprite openSprite;

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }
    
    private void OnAfterSceneLoadedEvent()
    {
        if (!isDone)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = openSprite;
            collider2D.enabled = false;
        }
    }

    protected override void OnClickedAction()
    {
        spriteRenderer.sprite = openSprite;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
