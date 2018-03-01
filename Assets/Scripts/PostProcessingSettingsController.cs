using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessingSettingsController : MonoBehaviour
{
    // Variables
    PostProcessingProfile newPostFxProfile;


    // Component references
    PostProcessingBehaviour postProcessContainer;

    // Called before start
    void Awake()
    {
        postProcessContainer = GetComponent<PostProcessingBehaviour>();

        // Get a copy of the original post processing profile
        newPostFxProfile = Instantiate(postProcessContainer.profile);
        postProcessContainer.profile = newPostFxProfile;


        // Adjust post fx quality
        adjustPostFxQuality();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Adjust post fx quality
    private void adjustPostFxQuality()
    {
        // If the graphics quality is low
        if (QualitySettings.GetQualityLevel() == 0)
        {
			newPostFxProfile.antialiasing.enabled = false;
			newPostFxProfile.depthOfField.enabled = false;
			newPostFxProfile.motionBlur.enabled = false;
			newPostFxProfile.screenSpaceReflection.enabled = false;

			var aoSetting = newPostFxProfile.ambientOcclusion.settings;
			aoSetting.sampleCount = AmbientOcclusionModel.SampleCount.Lowest;
			newPostFxProfile.ambientOcclusion.settings = aoSetting;
        }

		// If the graphics quality is medium
		else if (QualitySettings.GetQualityLevel() == 1)
		{
			// Adjust antialiasing
			var antiAliasingSetting = newPostFxProfile.antialiasing.settings;
			antiAliasingSetting.method = AntialiasingModel.Method.Fxaa;
			antiAliasingSetting.fxaaSettings.preset = AntialiasingModel.FxaaPreset.Quality;
			newPostFxProfile.antialiasing.settings = antiAliasingSetting;
		
			// Adjust depth of field
			var dofSetting = newPostFxProfile.depthOfField.settings;
			dofSetting.kernelSize = DepthOfFieldModel.KernelSize.Small;
			newPostFxProfile.depthOfField.settings = dofSetting;
			
			// Disable other effects
			newPostFxProfile.motionBlur.enabled = false;
			newPostFxProfile.screenSpaceReflection.enabled = false;
		}
    }
}
