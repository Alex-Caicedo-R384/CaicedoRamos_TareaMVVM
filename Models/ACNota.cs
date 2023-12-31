using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaicedoRamos_TareaMVVM.Models
{
    internal class Nota
    {
        public string ACFilename { get; set; }
        public string ACText { get; set; }
        public DateTime ACDate { get; set; }

        public Nota()
        {
            ACFilename = $"{Path.GetRandomFileName()}.notes.txt";
            ACDate = DateTime.Now;
            ACText = "";
        }

        public void Save() =>
            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, ACFilename), ACText);

        public void Delete() =>
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, ACFilename));

        public static Nota Load(string filename)
        {
            filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

            if (!File.Exists(filename))
                throw new FileNotFoundException("Unable to find file on local storage.", filename);

            return
                new()
                {
                    ACFilename = Path.GetFileName(filename),
                    ACText = File.ReadAllText(filename),
                    ACDate = File.GetLastWriteTime(filename)
                };
        }

        public static IEnumerable<Nota> LoadAll()
        {
            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            return Directory

                    // Select the file names from the directory
                    .EnumerateFiles(appDataPath, "*.notes.txt")

                    // Each file name is used to load a note
                    .Select(filename => Nota.Load(Path.GetFileName(filename)))

                    // With the final collection of notes, order them by date
                    .OrderByDescending(note => note.ACDate);
        }
    }
}
