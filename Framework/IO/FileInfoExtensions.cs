﻿using JetBrains.Annotations;
using System.IO;

namespace JJ.Framework.IO
{
    [PublicAPI]
    public static class FileInfoExtensions
    {
        public static void Hide(this FileInfo file) => FileHelper.HideFile(file);
        public static void Show(this FileInfo file) => FileHelper.ShowFile(file);
        public static bool IsHidden(this FileInfo file) => FileHelper.IsHidden(file);
        public static void MakeReadOnly(this FileInfo file) => FileHelper.MakeReadOnly(file);
        public static void MakeWritable(this FileInfo file) => FileHelper.MakeWritable(file);
        public static bool IsReadOnly(this FileInfo file) => FileHelper.IsReadOnly(file);
        public static byte[] ReadAllBytes(this FileInfo file) => File.ReadAllBytes(file.FullName);
    }
}