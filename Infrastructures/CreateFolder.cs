namespace DeltaruneFrBackEnd.Infrastructures
{
    public abstract class CreateFolder
    {
        public static void ProgressionFolder()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "ProgressionJson");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
