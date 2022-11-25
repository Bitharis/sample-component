namespace SampleComponent
{
    internal class Program
    {
        private const string ComponentDirecoryName = "AXIS Sample Certificate Component";
        private static string? acs_data_path;
        private static string? acs_installation_path;
        private static string? acs_deployment_environment;
        private static string? acs_firewall_configuration;
        private static string? acs_backup_path;

        static void Main(string[] args)
        {
            ReadEnvironmentVariables();

            if (args.Any())
            {
                var argument = args[0];

                switch (argument)
                {
                    case "install":
                        InstallWebServiceTo(acs_installation_path);
                        break;
                    case "uninstall":
                        UninstallWebServiceFrom(acs_installation_path);
                        break;
                    case "start":

                        break;
                    case "stop":

                        break;

                    case "status":

                        break;
                    case "backup":

                        break;
                    default:
                        Console.WriteLine("Unrecognized argument");
                        break;
                }
            }
        }

        private static void UninstallWebServiceFrom(string? acs_installation_path)
        {
            if (acs_installation_path == null)
            {
                Console.WriteLine($"{nameof(acs_installation_path)} is empty.");
                return;
            }

            var installationDirectory = Path.Combine(acs_installation_path, ComponentDirecoryName);
            if (Directory.Exists(installationDirectory))
            {
                Directory.Delete(installationDirectory, true);
            }
        }

        private static void InstallWebServiceTo(string? acs_installation_path)
        {
            if(acs_installation_path == null)
            {
                Console.WriteLine($"{nameof(acs_installation_path)} is empty.");
                return;
            }

            var installationDirectory = Path.Combine(acs_installation_path, ComponentDirecoryName);
            if (Directory.Exists(installationDirectory))
            {
                Directory.Delete(installationDirectory, true);
            }

            Directory.Move(ComponentDirecoryName, installationDirectory);
        }

        private static void ReadEnvironmentVariables()
        {
            Console.WriteLine("Reading environment variables...");

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                // Change the directory to %WINDIR%
                acs_data_path = Environment.GetEnvironmentVariable("ACS_COMPONENT_DATA_PATH");
                acs_installation_path = Environment.GetEnvironmentVariable("ACS_COMPONENT_INSTALLATION_PATH");
                acs_deployment_environment = Environment.GetEnvironmentVariable("ACS_DEPLOYMENT_ENVIRONMENT");
                acs_firewall_configuration = Environment.GetEnvironmentVariable("ACS_FIREWALL_CONFIGURATION");
                acs_backup_path = Environment.GetEnvironmentVariable("ACS_BACKUP_PATH");

                Console.WriteLine("$Env:ACS_COMPONENT_DATA_PATH: " + acs_data_path);
                Console.WriteLine("$Env:ACS_COMPONENT_INSTALLATION_PATH: " + acs_installation_path);
                Console.WriteLine("$Env:ACS_DEPLOYMENT_ENVIRONMENT: " + acs_deployment_environment);
                Console.WriteLine("$Env:ACS_FIREWALL_CONFIGURATION: " + acs_firewall_configuration);
                Console.WriteLine("$Env:ACS_BACKUP_PATH: " + acs_backup_path);

                Console.WriteLine("Finishded reading environment variables.");
            }
            else
            {
                Console.WriteLine("This example runs on Windows only.");
            }
        }
    }
}