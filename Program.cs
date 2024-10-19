using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

[assembly: DisableRuntimeMarshalling]

partial class Program
{
    static void Main()
    {
        try
        {
            string hostFxrPath = GetHostFxrPath();
            Console.WriteLine($"Got host FXR Path: {hostFxrPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to get host FXR path: {ex.Message}");
        }
    }

    private static string GetHostFxrPath()
    {
        if (OperatingSystem.IsWindows())
        {
            char[] buffer = new char[1024];
            nint bufferSize = buffer.Length;
            int rc = get_hostfxr_path_windows(buffer, ref bufferSize, IntPtr.Zero);
            if (rc == 0)
            {
                return new string(buffer.AsSpan().Slice(0, (int)bufferSize));
            }
            else
            {
                throw new Exception($"get_hostfxr_path failed: {rc}");
            }
        }
        else
        {
            byte[] buffer = new byte[1024];
            nint bufferSize = buffer.Length;
            int rc = get_hostfxr_path_non_windows(buffer, ref bufferSize, IntPtr.Zero);
            if (rc == 0)
            {
                return Encoding.UTF8.GetString(buffer.AsSpan().Slice(0, (int)bufferSize));
            }
            else
            {
                throw new Exception($"get_hostfxr_path failed: {rc}");
            }
        }
    }

    [LibraryImport("*", EntryPoint = "get_hostfxr_path")]
    private static partial int get_hostfxr_path_windows(char[] buffer, ref nint buffer_size, IntPtr parameters);

    [LibraryImport("*", EntryPoint = "get_hostfxr_path")]
    private static partial int get_hostfxr_path_non_windows(byte[] buffer, ref nint buffer_size, IntPtr parameters);
}
