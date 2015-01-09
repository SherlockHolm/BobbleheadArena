// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:Bumped Specular,lico:1,lgpr:1,nrmq:1,limd:0,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:8906,x:33394,y:32651,varname:node_8906,prsc:2|normal-2296-RGB,custl-8556-OUT;n:type:ShaderForge.SFN_Tex2d,id:5107,x:31571,y:32527,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_5107,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_LightVector,id:3462,x:30636,y:32821,varname:node_3462,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2213,x:30854,y:33142,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:2741,x:31083,y:32727,varname:node_2741,prsc:2,dt:0|A-3462-OUT,B-2213-OUT;n:type:ShaderForge.SFN_ViewVector,id:1259,x:30854,y:33324,varname:node_1259,prsc:2;n:type:ShaderForge.SFN_Dot,id:8201,x:31434,y:33255,varname:node_8201,prsc:2,dt:0|A-9723-OUT,B-1259-OUT;n:type:ShaderForge.SFN_Color,id:9578,x:31768,y:33566,ptovrint:False,ptlb:SpecColor,ptin:_SpecColor,varname:node_9578,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7512,x:32021,y:33408,varname:node_7512,prsc:2|A-5910-OUT,B-9578-RGB;n:type:ShaderForge.SFN_Power,id:5910,x:31768,y:33408,varname:node_5910,prsc:2|VAL-8201-OUT,EXP-3912-OUT;n:type:ShaderForge.SFN_Reflect,id:9723,x:31073,y:33095,varname:node_9723,prsc:2|A-7812-OUT,B-2213-OUT;n:type:ShaderForge.SFN_Slider,id:2258,x:30854,y:33484,ptovrint:False,ptlb:Shininess,ptin:_Shininess,varname:node_2258,prsc:2,min:0,cur:1.713925,max:17;n:type:ShaderForge.SFN_Multiply,id:5739,x:31858,y:32658,varname:node_5739,prsc:2|A-5107-RGB,B-9570-OUT;n:type:ShaderForge.SFN_Add,id:8556,x:32722,y:33201,varname:node_8556,prsc:2|A-5739-OUT,B-9514-RGB,C-4114-OUT;n:type:ShaderForge.SFN_Negate,id:7812,x:30854,y:32993,varname:node_7812,prsc:2|IN-3462-OUT;n:type:ShaderForge.SFN_Exp,id:3912,x:31434,y:33439,varname:node_3912,prsc:2,et:0|IN-2258-OUT;n:type:ShaderForge.SFN_Vector1,id:6764,x:31083,y:32632,varname:node_6764,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:8552,x:31328,y:32720,varname:node_8552,prsc:2|A-6764-OUT,B-2741-OUT;n:type:ShaderForge.SFN_Add,id:9570,x:31571,y:32720,varname:node_9570,prsc:2|A-6764-OUT,B-8552-OUT;n:type:ShaderForge.SFN_AmbientLight,id:9514,x:32301,y:33246,varname:node_9514,prsc:2;n:type:ShaderForge.SFN_Lerp,id:4114,x:32301,y:33461,varname:node_4114,prsc:2|A-2775-OUT,B-7512-OUT,T-4637-OUT;n:type:ShaderForge.SFN_Vector4,id:2775,x:32021,y:33542,varname:node_2775,prsc:2,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_LightVector,id:4499,x:31768,y:33729,varname:node_4499,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:7893,x:31768,y:33865,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:4637,x:32021,y:33729,varname:node_4637,prsc:2,dt:0|A-4499-OUT,B-7893-OUT;n:type:ShaderForge.SFN_Tex2d,id:2296,x:32860,y:32691,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_2296,prsc:2,ntxv:3,isnm:False;proporder:5107-9578-2258-2296;pass:END;sub:END;*/

Shader "Custom/PlasticShader" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _SpecColor ("SpecColor", Color) = (1,1,1,1)
        _Shininess ("Shininess", Range(0, 17)) = 1.713925
        _Normal ("Normal", 2D) = "bump" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _SpecColor;
            uniform float _Shininess;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_6764 = 0.2;
                float3 finalColor = ((_MainTex_var.rgb*(node_6764+(node_6764*dot(lightDirection,normalDirection))))+UNITY_LIGHTMODEL_AMBIENT.rgb+lerp(float4(0,0,0,0),float4((pow(dot(reflect((-1*lightDirection),normalDirection),viewDirection),exp(_Shininess))*_SpecColor.rgb),0.0),dot(lightDirection,i.normalDir))).rgb;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _SpecColor;
            uniform float _Shininess;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_6764 = 0.2;
                float3 finalColor = ((_MainTex_var.rgb*(node_6764+(node_6764*dot(lightDirection,normalDirection))))+UNITY_LIGHTMODEL_AMBIENT.rgb+lerp(float4(0,0,0,0),float4((pow(dot(reflect((-1*lightDirection),normalDirection),viewDirection),exp(_Shininess))*_SpecColor.rgb),0.0),dot(lightDirection,i.normalDir))).rgb;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Bumped Specular"
    CustomEditor "ShaderForgeMaterialInspector"
}
