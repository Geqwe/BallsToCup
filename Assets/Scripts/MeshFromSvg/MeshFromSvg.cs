using UnityEngine;
using Unity.VectorGraphics;
using SVGMeshUnity;
using System.IO;

public class MeshFromSvg : MonoBehaviour
{
    [SerializeField] private string _svgText;
    private SVGData SVG;
    private SVGMesh SvgMesh;

    void Start()
    {
        SvgMesh = GetComponent<SVGMesh>();
        SVG = new SVGData();
        SVG.Path(@"M42.5,0V13V13C46.9108,23.8696,34.8416,34.0366,24.8791,27.8438L23.4438,26.9516C13.659,20.8691,1,27.9055,1,39.4267L1,53.6599C1,62.9604,8.53956,70.5,17.8401,70.5H33.7541C38.5843,70.5,42.5,74.4157,42.5,79.2459V100.5");
        SvgMesh.Fill(SVG);
    }

//     void Update()
// {
//     SVG.Clear();

//     var resolution = 5;
//     var radius = 3f;
    
//     SVG.Move(NoisedR(radius, 0), 0f);
    
//     for (var i = 0; i < resolution; ++i)
//     {
//         var i0 = i;
//         var i1 = (i + 1) % resolution;
        
//         var angle0 = Mathf.PI * 2f * ((float) i0 / resolution);
//         var angle1 = Mathf.PI * 2f * ((float) i1 / resolution);

//         var r0 = NoisedR(radius, i0);
//         var r1 = NoisedR(radius, i1);
//         var x0 = Mathf.Cos(angle0) * r0;
//         var y0 = Mathf.Sin(angle0) * r0;
//         var x1 = Mathf.Cos(angle1) * r1;
//         var y1 = Mathf.Sin(angle1) * r1;

//         var cx = x0 + (x1 - x0) * 0.5f;
//         var cy = y0 + (y1 - y0) * 0.5f;
//         var ca = Mathf.Atan2(cy, cx);
//         var cr = 0.3f + (Mathf.PerlinNoise(Time.time, i * -100f) - 0.5f) * 1.15f;
//         cx += Mathf.Cos(ca) * cr;
//         cy += Mathf.Sin(ca) * cr;
        
//         SVG.Curve(cx, cy, cx, cy, x1, y1);
//     }
    
//     SvgMesh.Fill(SVG);
// }

// private float NoisedR(float r, float randomize)
// {
//     return r + (Mathf.PerlinNoise(Time.time, randomize * 10f) - 0.5f) * 0.5f;
// }

}
