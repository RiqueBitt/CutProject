using System;
using System.IO;

namespace Sprocket.App;

/// <summary>
/// O app se chamava "DaVinci Project" e guardava configurações, presets, plugins, autosave, logs e caches
/// em pastas com esse nome. Agora o nome é "CutProject": na primeira abertura, se a pasta antiga existir e a
/// nova ainda não, ela é renomeada — assim ninguém perde preferências, presets ou plugins na troca de nome.
/// Nunca apaga nada; se a renomeação falhar (pasta em uso, permissão), o app simplesmente segue com a pasta nova.
/// </summary>
internal static class LegacyDataMigration
{
    private const string OldName = "DaVinci Project";
    private const string NewName = "CutProject";

    public static void Run()
    {
        foreach (var folder in new[] { Environment.SpecialFolder.ApplicationData, Environment.SpecialFolder.LocalApplicationData })
        {
            try
            {
                string root = Environment.GetFolderPath(folder);
                if (string.IsNullOrEmpty(root)) continue;
                string oldDir = Path.Combine(root, OldName);
                string newDir = Path.Combine(root, NewName);
                if (Directory.Exists(oldDir) && !Directory.Exists(newDir))
                    Directory.Move(oldDir, newDir);
            }
            catch (Exception)
            {
                // Melhor seguir sem migrar do que impedir o app de abrir.
            }
        }
    }
}
