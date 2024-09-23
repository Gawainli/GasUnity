#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Haro.GAS
{
    [CreateAssetMenu(fileName = "AttributeSetConfig", menuName = "Gas/AttributeSetConfig", order = 0)]
    public class AttributeSetConfig : ScriptableObject
    {
        private const string KeyAutoGen = "//==自动化变量开始";
        private const string KeyAutoGenNew = "//==自动化创建开始";

        [Sirenix.OdinInspector.FilePath(Extensions = "txt", RequireExistingPath = true)]
        public string templateCodePath;

        [Sirenix.OdinInspector.FolderPath(RequireExistingPath = true)]
        public string codeGeneratePath;

        [FormerlySerializedAs("codeNamespace")]
        public string genCodeNamespace;

        public List<string> attributeNameTexts;

        [Button]
        private void GenerateCode()
        {
            var genClassName = name;

            var codeGenFilePath = $"{codeGeneratePath}/{genClassName}.Gen.cs";
            var codeNormalFilePath = $"{codeGeneratePath}/{genClassName}.cs";

            var streamReader = new StreamReader(templateCodePath, Encoding.UTF8);
            var classText = streamReader.ReadToEnd();
            streamReader.Close();

            //命名空间
            if (!string.IsNullOrEmpty(genCodeNamespace))
            {
                classText = classText.Replace("Haro.GAS.Template", genCodeNamespace);
            }

            //类名
            classText = classText.Replace("AttributeSetTemplate", genClassName);

            //写入实现类文件
            var normalClassText = classText.Replace(KeyAutoGen, "//实现virtual方法");
            Debug.Log(normalClassText);

            if (File.Exists(codeNormalFilePath))
            {
                Debug.LogWarning($"{codeNormalFilePath} is already exist!");
            }
            else
            {
                var normalCodeWriter = new StreamWriter(codeNormalFilePath, false, Encoding.UTF8);
                normalCodeWriter.Write(normalClassText);
                normalCodeWriter.Close();
            }


            //生成attribute变量
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("\n");
            foreach (var attributeNameText in attributeNameTexts)
            {
                stringBuilder.Append($"        public Attribute {attributeNameText};\n");
            }

            classText = classText.Replace(KeyAutoGen, KeyAutoGen + stringBuilder.ToString());

            //生成attribute创建
            stringBuilder.Clear();
            stringBuilder.Append("\n");
            foreach (var attributeNameText in attributeNameTexts)
            {
                stringBuilder.Append($"            {attributeNameText} = CreateAttribute(\"{attributeNameText}\");\n");
            }

            classText = classText.Replace(KeyAutoGenNew, KeyAutoGenNew + stringBuilder.ToString());

            //写入自动生成类文件
            Debug.Log(codeGenFilePath);
            var genCodeWriter = new StreamWriter(codeGenFilePath, false, Encoding.UTF8);
            genCodeWriter.Write(classText);
            genCodeWriter.Close();
            AssetDatabase.Refresh();
        }
    }
}
#endif