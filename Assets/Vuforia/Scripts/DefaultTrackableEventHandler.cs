/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// 
/// Changes made to this file could be overwritten when upgrading the Vuforia version. 
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    private AudioSource soundTarget;
    private AudioSource[] allAudioSources;
    public GameObject panelText;
    public GameObject buttonVermas;
    public GameObject textName;
    static public string imageTargetName;
    public GameObject treeTitleName;
    public GameObject treeSciName;
    public GameObject treeAbout;
    public GameObject treeLongAbout;
    private int trackNumber;
    private RawImage img;


    //function to stop all sounds
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    //function to play sound
    IEnumerator PlaySound(int ss)
    {
        Debug.Log("Paso por aqui");
        using (var www = new WWW((string)Databse.audioList[ss]))
        {

            yield return www;
            soundTarget.clip = www.GetAudioClip(true, true, AudioType.MPEG);

        }
        soundTarget.loop = false;
        soundTarget.playOnAwake = false;
        soundTarget.Play();
    }

    IEnumerator LoadImage(int ss)
    {
        using (var www = new WWW((string)Databse.imageList[ss]))
        {

            yield return www;
            img.texture = www.texture;

        }
    }

    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        Scene actualScene = SceneManager.GetActiveScene();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        if(actualScene.name == "TreeInfo")
            img = GameObject.Find("treeImage").GetComponent<RawImage>();
        /// Dependiendo del nombre del target cambio el titulo del texto
        if (imageTargetName == "1")
        {
            trackNumber = 27;
            StartCoroutine(LoadImage(27));
            treeTitleName.GetComponent<Text>().text = "Vegetación del bosque seco Tropical";
            treeSciName.GetComponent<Text>().text = "Uninorte";

        }
        if (imageTargetName == "2")
        {
            trackNumber = 26;
            StartCoroutine(LoadImage(26));
            treeTitleName.GetComponent<Text>().text = "La Fauna del Bosque seco tropical";
            treeSciName.GetComponent<Text>().text = "Uninorte";
        }
        if (imageTargetName == "3")
        {
            trackNumber = 25;
            StartCoroutine(LoadImage(25));
            treeTitleName.GetComponent<Text>().text = "Edificio sostenible";
            treeSciName.GetComponent<Text>().text = "Uninorte";

        }
        if (imageTargetName == "4")
        {
            trackNumber = 24;
            StartCoroutine(LoadImage(24));
            treeTitleName.GetComponent<Text>().text = "Centro de acopio de residuos sólidos";
            treeSciName.GetComponent<Text>().text = "Uninorte";
        }
        if (imageTargetName == "5")
        {
            trackNumber = 23;
            StartCoroutine(LoadImage(23));
            treeTitleName.GetComponent<Text>().text = "Zona de Observación de aves";
            treeSciName.GetComponent<Text>().text = "Uninorte";

        }
        if (imageTargetName == "6")
        {
            trackNumber = 22;
            StartCoroutine(LoadImage(22));
            treeTitleName.GetComponent<Text>().text = "Roble Amarillo";
            treeSciName.GetComponent<Text>().text = "Handroanthus chrysanthus";
        }
        if (imageTargetName == "7")
        {
            trackNumber = 21;
            StartCoroutine(LoadImage(21));
            treeTitleName.GetComponent<Text>().text = "Diversidad biocultural";
            treeSciName.GetComponent<Text>().text = "Ceiba Roja";

        }
        if (imageTargetName == "8")
        {
            trackNumber = 20;
            StartCoroutine(LoadImage(20));
            treeTitleName.GetComponent<Text>().text = "Los servicios de los ecosistemas";
            treeSciName.GetComponent<Text>().text = "Uninorte";

        }
        if (imageTargetName == "9")
        {
            trackNumber = 19;
            StartCoroutine(LoadImage(19));
            treeTitleName.GetComponent<Text>().text = "Los árboles regulan el clima";
            treeSciName.GetComponent<Text>().text = "Uninorte";
        }
        if (imageTargetName == "10")
        {
            trackNumber = 18;
            StartCoroutine(LoadImage(18));
            treeTitleName.GetComponent<Text>().text = "Aula viva";
            treeSciName.GetComponent<Text>().text = "Uninorte";

        }
        if (imageTargetName == "11")
        {
            trackNumber = 17;
            StartCoroutine(LoadImage(17));
            treeTitleName.GetComponent<Text>().text = "Lluvia de oro";
            treeSciName.GetComponent<Text>().text = "Cassia fistula";
        }
        if (imageTargetName == "12")
        {
            trackNumber = 16;
            StartCoroutine(LoadImage(16));
            treeTitleName.GetComponent<Text>().text = "Arbol de pan";
            treeSciName.GetComponent<Text>().text = "Artocarpus altilis";

        }
        if (imageTargetName == "13")
        {
            trackNumber = 15;
            StartCoroutine(LoadImage(15));
            treeTitleName.GetComponent<Text>().text = "Roble morado";
            treeSciName.GetComponent<Text>().text = "Tabebuia rosea";
        }
        if (imageTargetName == "14")
        {
            trackNumber = 14;
            StartCoroutine(LoadImage(14));
            treeTitleName.GetComponent<Text>().text = "Bonga";
            treeSciName.GetComponent<Text>().text = "Árbol de la resiliencia";

        }
        if (imageTargetName == "15")
        {
            trackNumber = 13;
            StartCoroutine(LoadImage(13));
            treeTitleName.GetComponent<Text>().text = "Ceiba blanca";
            treeSciName.GetComponent<Text>().text = "Hura crepitans";
        }
        if (imageTargetName == "16")
        {
            trackNumber = 12;
            StartCoroutine(LoadImage(12));
            treeTitleName.GetComponent<Text>().text = "Roble amarillo";
            treeSciName.GetComponent<Text>().text = "Handroanthus chrysanthus";

        }
        if (imageTargetName == "17")
        {
            trackNumber = 11;
            StartCoroutine(LoadImage(11));
            treeTitleName.GetComponent<Text>().text = "Azuceno blanco";
            treeSciName.GetComponent<Text>().text = "Plumeria alba";
        }
        if (imageTargetName == "18")
        {
            trackNumber = 10;
            StartCoroutine(LoadImage(10));
            treeTitleName.GetComponent<Text>().text = "Alstonia";
            treeSciName.GetComponent<Text>().text = "Alstonia scholaris";
        }
        if (imageTargetName == "19")
        {
            trackNumber = 9;
            StartCoroutine(LoadImage(9));
            treeTitleName.GetComponent<Text>().text = "Palma real";
            treeSciName.GetComponent<Text>().text = "Roystonea regia";

        }
        if (imageTargetName == "20")
        {
            trackNumber = 8;
            StartCoroutine(LoadImage(8));
            treeTitleName.GetComponent<Text>().text = "Coralibe";
            treeSciName.GetComponent<Text>().text = "Handroanthus coralibe";
        }
        if (imageTargetName == "21")
        {
            trackNumber = 7;
            StartCoroutine(LoadImage(7));
            treeTitleName.GetComponent<Text>().text = "Acacia roja";
            treeSciName.GetComponent<Text>().text = "Delonix regia";

        }
        if (imageTargetName == "22")
        {
            trackNumber = 6;
            StartCoroutine(LoadImage(6));
            treeTitleName.GetComponent<Text>().text = "Almendro";
            treeSciName.GetComponent<Text>().text = "Terminalia catappa";
        }
        if (imageTargetName == "23")
        {
            trackNumber = 5;
            StartCoroutine(LoadImage(5));
            treeTitleName.GetComponent<Text>().text = "Higuerón";
            treeSciName.GetComponent<Text>().text = "Ficus elastica";

        }
        if (imageTargetName == "24")
        {
            trackNumber = 4;
            StartCoroutine(LoadImage(4));
            treeTitleName.GetComponent<Text>().text = "Mango";
            treeSciName.GetComponent<Text>().text = "Mangifera indica";
        }
        if (imageTargetName == "25")
        {
            trackNumber = 3;
            StartCoroutine(LoadImage(3));
            treeTitleName.GetComponent<Text>().text = "Palma amarga";
            treeSciName.GetComponent<Text>().text = "Sabal mauritiiformis";

        }
        if (imageTargetName == "26")
        {
            trackNumber = 2;
            StartCoroutine(LoadImage(2));
            treeTitleName.GetComponent<Text>().text = "Matarratón";
            treeSciName.GetComponent<Text>().text = "Gliricidia sepium";
        }
        if (imageTargetName == "27")
        {
            trackNumber = 1;
            StartCoroutine(LoadImage(1));
            treeTitleName.GetComponent<Text>().text = "Anón";
            treeSciName.GetComponent<Text>().text = "Annona squamosa";
        }
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
        // Cada vez que se encuentra un target guardo el nombre y evaluo 
        imageTargetName = mTrackableBehaviour.TrackableName;
        Debug.Log("Es " + imageTargetName);

        if (mTrackableBehaviour.TrackableName == "1")
        {
            StartCoroutine(PlaySound(27));
            textName.GetComponent<Text>().text = "Vegetación del bosque seco Tropical";
        }
        if (mTrackableBehaviour.TrackableName == "2")
        {
            StartCoroutine(PlaySound(26));
            textName.GetComponent<Text>().text = "La Fauna del Bosque seco tropical";
        }
        if (mTrackableBehaviour.TrackableName == "3")
        {
            StartCoroutine(PlaySound(25));
            textName.GetComponent<Text>().text = "Edificio sostenible";
        }
        if (mTrackableBehaviour.TrackableName == "4")
        {
            StartCoroutine(PlaySound(24));
            textName.GetComponent<Text>().text = "Centro de acopio de residuos sólidos";
        }
        if (mTrackableBehaviour.TrackableName == "5")
        {
            StartCoroutine(PlaySound(23));
            textName.GetComponent<Text>().text = "Zona de Observación de aves";
        }
        if (mTrackableBehaviour.TrackableName == "6")
        {
            StartCoroutine(PlaySound(22));
            textName.GetComponent<Text>().text = "Roble Amarillo \n Handroanthus chrysanthus \n";
        }
        if (mTrackableBehaviour.TrackableName == "7")
        {
            StartCoroutine(PlaySound(21));
            textName.GetComponent<Text>().text = "Diversidad biocultural \n Ceiba Roja \n Pachira quinata";
        }
        if (mTrackableBehaviour.TrackableName == "8")
        {
            StartCoroutine(PlaySound(20));
            textName.GetComponent<Text>().text = "Los servicios de los ecosistemas";
        }
        if (mTrackableBehaviour.TrackableName == "9")
        {
            StartCoroutine(PlaySound(19));
            textName.GetComponent<Text>().text = "Los árboles regulan el clima";
        }
        if (mTrackableBehaviour.TrackableName == "10")
        {
            StartCoroutine(PlaySound(18));
            textName.GetComponent<Text>().text = "Aula viva";
        }
        if (mTrackableBehaviour.TrackableName == "11")
        {
            StartCoroutine(PlaySound(17));
            textName.GetComponent<Text>().text = "Lluvia de oro \nCassia fistula \n";
        }
        if (mTrackableBehaviour.TrackableName == "12")
        {
            StartCoroutine(PlaySound(16));
            textName.GetComponent<Text>().text = "Arbol de pan \n Artocarpus altilis \n";
        }
        if (mTrackableBehaviour.TrackableName == "13")
        {
            StartCoroutine(PlaySound(15));
            textName.GetComponent<Text>().text = "Roble morado \n Tabebuia rosea \n";
        }
        if (mTrackableBehaviour.TrackableName == "14")
        {
            StartCoroutine(PlaySound(14));
            textName.GetComponent<Text>().text = "Bonga \n Árbol de la resiliencia \n";
        }
        if (mTrackableBehaviour.TrackableName == "15")
        {
            StartCoroutine(PlaySound(13));
            textName.GetComponent<Text>().text = "Ceiba blanca \n Hura crepitans \n";
        }
        if (mTrackableBehaviour.TrackableName == "16")
        {
            StartCoroutine(PlaySound(12));
            textName.GetComponent<Text>().text = "Roble amarillo \n Handroanthus chrysanthus \n";
        }
        if (mTrackableBehaviour.TrackableName == "17")
        {
            StartCoroutine(PlaySound(11));
            textName.GetComponent<Text>().text = "Azuceno blanco \n Plumeria alba \n";
        }
        if (mTrackableBehaviour.TrackableName == "18")
        {
            StartCoroutine(PlaySound(10));
            textName.GetComponent<Text>().text = "Alstonia \n Alstonia scholaris \n";
        }
        if (mTrackableBehaviour.TrackableName == "19")
        {
            StartCoroutine(PlaySound(9));
            textName.GetComponent<Text>().text = "Palma real \n Roystonea regia \n";
        }
        if (mTrackableBehaviour.TrackableName == "20")
        {
            StartCoroutine(PlaySound(8));
            textName.GetComponent<Text>().text = "Coralibe \n Handroanthus coralibe \n";
        }
        if (mTrackableBehaviour.TrackableName == "21")
        {
            StartCoroutine(PlaySound(7));
            textName.GetComponent<Text>().text = "Acacia roja \n Delonix regia \n";
        }
        if (mTrackableBehaviour.TrackableName == "22")
        {
            StartCoroutine(PlaySound(6));
            textName.GetComponent<Text>().text = "Almendro \n Terminalia catappa \n";
        }
        if (mTrackableBehaviour.TrackableName == "23")
        {
            StartCoroutine(PlaySound(5));
            textName.GetComponent<Text>().text = "Higuerón \n Ficus elastica \n ";
        }
        if (mTrackableBehaviour.TrackableName == "24")
        {
            StartCoroutine(PlaySound(4));
            textName.GetComponent<Text>().text = "Mango \n Mangifera indica \n";
        }
        if (mTrackableBehaviour.TrackableName == "25")
        {
            StartCoroutine(PlaySound(3));
            textName.GetComponent<Text>().text = "Palma amarga \n Sabal mauritiiformis \n";
        }
        if (mTrackableBehaviour.TrackableName == "26")
        {
            StartCoroutine(PlaySound(2));
            textName.GetComponent<Text>().text = "Matarratón \n Gliricidia sepium \n";
        }
        if (mTrackableBehaviour.TrackableName == "27")
        {
            StartCoroutine(PlaySound(1));
            textName.GetComponent<Text>().text = "Anón \n Annona squamosa \n";
        }

        panelText.SetActive(true);
        buttonVermas.SetActive(true);
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;

        StopAllAudio();
        panelText.SetActive(false);
        buttonVermas.SetActive(false);
    }

    #endregion // PROTECTED_METHODS


    private void Update()
    {
        Scene actualScene = SceneManager.GetActiveScene();
        if (Databse.modelList.Count < 20 && Databse.longTextList.Count < 20)
        {
            if (actualScene.name == "TreeInfo")
                treeAbout.GetComponent<Text>().text = "Cargando";

            if (actualScene.name == "TreeInfo")
                treeLongAbout.GetComponent<Text>().text = "Cargando";
        }
        else
        {

            if (actualScene.name == "TreeInfo")
                treeAbout.GetComponent<Text>().text = (string)Databse.modelList[trackNumber];
                

            if (actualScene.name == "TreeLongInfo")
                treeLongAbout.GetComponent<Text>().text = (string)Databse.longTextList[trackNumber];
        }
    }

}
