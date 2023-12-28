namespace pracaInż.Extensions
{
    public static class Copy
    {
        public static void Start()
        {
            TimeSpan interval = TimeSpan.FromDays(3);
            var timer = new Timer(BackupFiles, null, TimeSpan.Zero, interval);
        }

        public static void BackupFiles(object state)
        {
            string path = @"C:\Users\zablockin\Source\Repos\Zablo100\PracaInz\pracaInż\Files\";
            string pathToBackup = @"D:\Kopia";

            foreach (string fileName in Directory.GetFileSystemEntries(path))
            {
                try
                {
                    File.Copy(fileName, Path.Combine(pathToBackup, Path.GetFileName(fileName)), true);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Błąd podczas kopiowania plików!");
                }
            }
            Console.WriteLine("Zakończono proces kopiowania danych");
        }
    }
}
