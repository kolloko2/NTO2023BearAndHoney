using System;
using System.Collections;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        public CanvasGroup Curtain;
        public SpriteRenderer LoadingScreenSpriteRender;
        private  float _alphaChannel;

        private void Awake()
        {
            LoadingScreenSpriteRender = gameObject.GetComponentInChildren<SpriteRenderer>();
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            
            gameObject.GetComponent<Canvas>().worldCamera=Camera.main;
            gameObject.SetActive(true);
            
            
            _alphaChannel = 1f;
            Curtain.alpha = 1;
            LoadingScreenSpriteRender.color= new Color(LoadingScreenSpriteRender.color.r,LoadingScreenSpriteRender.color.g,LoadingScreenSpriteRender.color.b,_alphaChannel);
            
        }

        public void Hide()
        {
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            while (_alphaChannel>0)
            {
             
               
                _alphaChannel -= 0.01f;
                Curtain.alpha = _alphaChannel;
                
                
                LoadingScreenSpriteRender.color= new Color(LoadingScreenSpriteRender.color.r,LoadingScreenSpriteRender.color.g,LoadingScreenSpriteRender.color.b,_alphaChannel);
                yield return new WaitForSeconds(0.01f);
            }

            gameObject.SetActive(false);
        }
    }
}