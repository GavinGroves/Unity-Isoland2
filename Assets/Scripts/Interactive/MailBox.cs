using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class MailBox : Interactive
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D coll;
    [SerializeField] private Sprite openImage;
    [SerializeField] private GameObject ticket;

    private void OnEnable()
    {
        EventHandler.SaveAfterSceneEvent += OnSaveAfterSceneEvent;
    }

    private void OnDisable()
    {
        EventHandler.SaveAfterSceneEvent -= OnSaveAfterSceneEvent;
    }

    private void OnSaveAfterSceneEvent()
    {
        if (!isDone)
        {
            ticket.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = openImage;
            coll.enabled = false;
        }
    }

    protected override void OnClickedAction()
    {
        spriteRenderer.sprite = openImage;
        ticket.SetActive(true);           
    }
}
