using UnityEngine;
public class DayCycleManager : MonoBehaviour
{
    [SerializeField] private Light SunLight;

    [Range(0f, 1f)] 
    [SerializeField] private float TimeOfDay;
    [SerializeField] private float DayDuration;
    
    [SerializeField] private Gradient directionalLightGradient;

    [SerializeField] private AnimationCurve SunCurve;
    [SerializeField] private AnimationCurve SkyBoxCurve;

    public Material DaySkybox;
    public Material NightSkybox;

    [SerializeField] private ParticleSystem Stars;

    private float sunIntensity;

    private void Start()
    {
        sunIntensity = SunLight.intensity;
    }

    private void Update()
    {
        TimeOfDay += Time.deltaTime / DayDuration;
        if (TimeOfDay >= 1) TimeOfDay -= 1;

        if (TimeOfDay >= 0.55f && TimeOfDay <=0.93f) RenderSettings.skybox = NightSkybox;
        else RenderSettings.skybox = DaySkybox;
        SunLight.color = directionalLightGradient.Evaluate(TimeOfDay);
        // RenderSettings.skybox.Lerp(NightSkybox,DaySkybox,SkyBoxCurve.Evaluate(TimeOfDay));
        // DynamicGI.UpdateEnvironment();

        /*
         *  Строчки для отрисовки звёзд
         */
        var mainModule = Stars.main;
        mainModule.startColor = new Color(1, 1, 1, 1 - SkyBoxCurve.Evaluate(TimeOfDay));
        
        /*
        * Поворот источников света
        */
        SunLight.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f,180,0);

        /*
         * Присвоение интенсивности источникам света с помощью кривой
         */
        SunLight.intensity = sunIntensity * SunCurve.Evaluate(TimeOfDay);
    }
}
