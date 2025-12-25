using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using QLNhaSach.Models;

namespace QLNhaSach.Tools
{
    public static class DatabaseSeeder
    {
        // Try to find SampleData.sql in parent folders
        public static string FindSampleSqlFile()
        {
            var dir = AppContext.BaseDirectory;
            for (int i = 0; i < 8; i++)
            {
                var candidate = Path.Combine(dir, "SampleData.sql");
                if (File.Exists(candidate)) return candidate;
                dir = Path.GetDirectoryName(dir) ?? dir;
            }
            return null;
        }

        public static void SeedFromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                throw new FileNotFoundException("SQL file not found", filePath);

            var sql = File.ReadAllText(filePath);
            // Split batches on lines that contain only GO (case-insensitive)
            var batches = Regex.Split(sql, "^\\s*GO\\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase)
                .Select(b => b.Trim()).Where(b => !string.IsNullOrWhiteSpace(b)).ToList();

            using var db = new QuanLyNhaSachContext();
            foreach (var batch in batches)
            {
                db.Database.ExecuteSqlRaw(batch);
            }
        }

        public static void SeedSampleDataIfArg(string[] args)
        {
            if (args == null) return;
            if (!args.Contains("--seed", StringComparer.OrdinalIgnoreCase)) return;
            var file = FindSampleSqlFile();
            if (file == null) throw new FileNotFoundException("Could not locate SampleData.sql in parent folders.");
            SeedFromFile(file);
        }
    }
}
