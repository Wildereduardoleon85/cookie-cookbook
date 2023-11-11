using Cookie_Cookbook.Enums;

namespace Cookie_Cookbook.Conf
{
    public class FileConf
    {
        public string Name { get; } = "recipe";
        public FileFormat Format { get; } = FileFormat.Json;

        public string GetFilePath()
        {
            string path = $"{Name}.json";

            if (Format == FileFormat.Txt)
            {
                path = $"{Name}.txt";
            }

            return path;
        }
    }
}