using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIObj_Announce : MonoBehaviour
{
    public Image img;
    private Camera mainCamera;

    public float tweenTarg;

    private Tween moveTween;

    void Start (){
        mainCamera = Camera.main;
        start_tween ();
    }

    void Update (){
        update_targ_pos ();
    }

    private void start_tween(){
        transform.localPosition = new Vector2 (0, Screen.height / 3f);
        transform.localScale = Vector2.zero;

        transform.DOScale (Vector3.one, 0.75f)
            .OnComplete (() => {
                Vector3 _targPos = mainCamera.ViewportToWorldPoint (new Vector3(tweenTarg, 1, mainCamera.nearClipPlane));

                moveTween = transform.DOMove(_targPos, 0.75f)
                    .OnStart (() => {
                        transform.DOScale (Vector3.one * 0.2f, 0.75f);
                    })
                    .OnComplete (() => {
                        Destroy (gameObject);
                    });
            });
    }

    private void update_targ_pos (){
        if (moveTween != null && moveTween.IsActive ()) {
            Vector3 _targPos = mainCamera.ViewportToWorldPoint (new Vector3(tweenTarg, 1, mainCamera.nearClipPlane));
            Vector3 _cam = mainCamera.transform.position;
            Vector3 _updatedPos = _targPos + new Vector3(_cam.x, 0, 0);

            float _remTime = moveTween.Duration() - moveTween.Elapsed();
            transform.DOMove(_updatedPos, _remTime);
        }
    }
}
