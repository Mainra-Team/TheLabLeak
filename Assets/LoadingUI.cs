using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : BaseUI
{
    [SerializeField]private Slider sliderLoading;
    
    public void LoadingProgress(float progress)
    {
        sliderLoading.value = progress;
    }
}
