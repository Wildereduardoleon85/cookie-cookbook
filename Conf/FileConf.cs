using Cookie_Cookbook.Enums;

namespace Cookie_Cookbook.Conf
{
    public class FileConf
    {
        public string Name { get; } = "recipe";
        public FileFormat Format { get; } = FileFormat.Txt;
    }
}