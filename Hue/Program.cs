using System.Diagnostics;

public static class HelperProcesos
{
    public static bool EstaProcesoAbierto(string nombreProceso)
    {
        if (string.IsNullOrWhiteSpace(nombreProceso))
            return false;

        if (nombreProceso.EndsWith(".exe", System.StringComparison.OrdinalIgnoreCase))
        {
            nombreProceso = nombreProceso.Substring(0, nombreProceso.Length - 4);
        }

        return Process.GetProcessesByName(nombreProceso).Length > 0;
    }

    public static void CerrarProceso(string nombreProceso)
    {
        if (string.IsNullOrWhiteSpace(nombreProceso))
            return;

        if (nombreProceso.EndsWith(".exe", System.StringComparison.OrdinalIgnoreCase))
        {
            nombreProceso = nombreProceso.Substring(0, nombreProceso.Length - 4);
        }

        foreach (var proceso in Process.GetProcessesByName(nombreProceso))
        {
            try
            {
                proceso.Kill();
                proceso.WaitForExit(10000);
                Console.WriteLine($"Proceso cerrado: {nombreProceso}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo cerrar {nombreProceso}: {ex.Message}");
            }
        }
    }

    public static void VerificarProcesoCada5Segundos(string nombreProceso)
    {
        while (true)
        {
            bool abierto = EstaProcesoAbierto(nombreProceso);
            if (abierto)
            {
                Console.WriteLine($"{nombreProceso}: abierto -> cerrado...");
                CerrarProceso(nombreProceso);
            }
            else
            {
                Console.WriteLine($"{nombreProceso}: cerrado");
            }

            Thread.Sleep(5000);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string nombreProceso = args.Length > 0 ? args[0] : "eclipse";
        HelperProcesos.VerificarProcesoCada5Segundos(nombreProceso);
    }
}