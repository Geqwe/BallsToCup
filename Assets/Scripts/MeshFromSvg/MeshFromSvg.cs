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
}
