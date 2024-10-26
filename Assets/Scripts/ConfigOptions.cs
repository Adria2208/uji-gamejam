using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfigOptions : MonoBehaviour
{
    #region AUDIORELATED
    [SerializeField] private Slider VolumeSlider;
    private float volumeValue;
    #endregion

    #region VIDEOREALTED
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private int selectedResolution;
    [SerializeField] private Toggle fullScreenToggle;
    private bool fullscreenBool;
    private bool antibug;

    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private GameObject brightnessPanel;
    private float brightnessValue;
    #endregion

    private void Awake()
    {
        antibug=true;
        LoadStoredSettings();
        RefrescarMenus();
        antibug=false;
    }

    private void LoadStoredSettings(){
        #region AUDIORELATED
        if(PlayerPrefs.HasKey("GVolume")){
            volumeValue = PlayerPrefs.GetFloat("GVolume");            
            }
            else{
            volumeValue = 1f;
            PlayerPrefs.SetFloat("GVolume", volumeValue);
            }

        #endregion

        #region VIDEOREALTED
            #region RESOLUTION
            if(PlayerPrefs.HasKey("Fullscreen")){
                fullscreenBool = bool.Parse(PlayerPrefs.GetString("Fullscreen"));
                }
                else{
                fullscreenBool = true;
                PlayerPrefs.SetString("Fullscreen", "true");
                }
            
            
            if(PlayerPrefs.HasKey("SelectResolution")){
                selectedResolution = PlayerPrefs.GetInt("SelectResolution");            
                }
                else{
                selectedResolution = 2;
                PlayerPrefs.SetInt("SelectResolution", selectedResolution);
                }
                
            if(selectedResolution==0)
            {
                Screen.SetResolution(1280, 720, fullscreenBool);
                Debug.Log("Lowres");
            }
            else if(selectedResolution==1)
            {
                Screen.SetResolution(1366, 768, fullscreenBool);
                Debug.Log("Midres");
            }
            else if(selectedResolution==2)
            {
                Screen.SetResolution(1920, 1080, fullscreenBool);
            }
            #endregion


        if(PlayerPrefs.HasKey("Brightness")){
            brightnessValue = PlayerPrefs.GetFloat("Brightness");            
            }
            else{
            brightnessValue = 0.15f;
            PlayerPrefs.SetFloat("Brightness", brightnessValue);
            }
        #endregion
    }

    private void RefrescarMenus(){
        VolumeSlider.value = volumeValue;
        fullScreenToggle.GetComponent<Toggle>().isOn = fullscreenBool;
        Screen.SetResolution(Screen.width, Screen.height, fullscreenBool);
        resolutionDropdown.value = selectedResolution;
        resolutionDropdown.RefreshShownValue();
        brightnessSlider.value = brightnessValue;
        brightnessPanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, brightnessValue);
    }

    public void DropDownSelection(TMP_Dropdown index){

        selectedResolution = index.value;
        if(selectedResolution==0)
            {
                Screen.SetResolution(1280, 720, fullscreenBool);
            }
            else if(selectedResolution==1)
            {
                Screen.SetResolution(1366, 768, fullscreenBool);
            }
            else if(selectedResolution==2)
            {
                Screen.SetResolution(1920, 1080, fullscreenBool);
            }
        PlayerPrefs.SetInt("SelectResolution", selectedResolution);
    }
    
    public void ToggleFullscreen(){
        if(!antibug){
        fullscreenBool=!fullscreenBool;
        Screen.SetResolution(Screen.width, Screen.height, fullscreenBool);
        PlayerPrefs.SetString("Fullscreen", fullscreenBool.ToString());
        Debug.Log(PlayerPrefs.GetString("Fullscreen"));
        }
    }

    public void UIBrightnessSlider(){
        brightnessValue = brightnessSlider.value;
        brightnessPanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, brightnessValue);
        PlayerPrefs.SetFloat("Brightness", brightnessValue);
    }

    public void UIVolumeSlider(){
        volumeValue = VolumeSlider.value;
        PlayerPrefs.SetFloat("GVolume", volumeValue);
    }

    public void ResetAudio(){
        volumeValue = 1f;
        PlayerPrefs.SetFloat("GVolume", volumeValue);    
        VolumeSlider.value = volumeValue;
    }

    public void ResetVideo(){
        fullscreenBool = true;
        selectedResolution = 2;
        brightnessValue = 0.15f;
        Screen.SetResolution(1920, 1080, fullscreenBool);
        PlayerPrefs.SetInt("SelectResolution", selectedResolution);
        PlayerPrefs.SetString("Fullscreen", "true");
        PlayerPrefs.SetFloat("Brightness", brightnessValue);
        RefrescarMenus();
    }

}
